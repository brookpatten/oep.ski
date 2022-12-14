using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authentication;

using Amphibian.Oep.Api.Repositories;
using Amphibian.Oep.Api.Models;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Text.Json;
using Amphibian.Oep.Api.Dtos;
using Amphibian.Oep.Api.Extensions;
using Amphibian.Oep.Configuration;
using System.Text.Json.Serialization;

namespace Amphibian.Oep.Api.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly ILogger<AuthenticationService> _logger;
        private readonly IUserRepository _userRepository;
        private readonly IPasswordService _passwordService;
        private readonly ITokenRepository _tokenRepository;
        private readonly ISystemClock _systemClock;
        private readonly ISysAdminService _sysAdminService;
        private readonly string _jwtKey;
        private readonly string _jwtIssuer;

        public AuthenticationService(ILogger<AuthenticationService> logger, IUserRepository userRepository, IPasswordService passwordService, 
            ITokenRepository tokenRepository, ISystemClock systemClock, AppConfiguration configuration, ISysAdminService sysAdminService)
        {
            _logger = logger;
            _userRepository = userRepository;
            _passwordService = passwordService;
            _tokenRepository = tokenRepository;
            _systemClock = systemClock;
            _jwtKey = configuration.JwtKey;
            _jwtIssuer = configuration.RootUrl;
            _sysAdminService = sysAdminService;
        }

        public async Task<Token> CreateNewTokenForUser(User user)
        {
            var now = _systemClock.UtcNow.UtcDateTime;
            var newToken = new Token()
            {
                CreatedAt = now,
                LastRequestAt = now,
                TokenGuid = Guid.NewGuid(),
                UserId = user.Id
            };
            await _tokenRepository.InsertToken(newToken);
            return newToken;
        }

        public string CreateSignedJwtToken(Token token, UserIdentifier user, bool minimal=false )
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            //Create a List of Claims, Keep claims name short    
            var permClaims = new List<Claim>();
            permClaims.Add(new Claim(JwtRegisteredClaimNames.Jti, token.TokenGuid.ToString()));
            permClaims.Add(new Claim(JwtRegisteredClaimNames.Iss, _jwtIssuer));
            permClaims.Add(new Claim(JwtRegisteredClaimNames.Iat, token.CreatedAt.ToUnixTime().ToString()));
            permClaims.Add(new Claim("uid", user.Id.ToString()));

            if (!minimal)
            {
                var options = new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
                options.Converters.Add(new JsonStringEnumConverter());
            }
            else
            {
                permClaims.Add(new Claim("minimal", minimal.ToString()));
            }

            if(_sysAdminService.IsUserSysAdmin(user))
            {
                permClaims.Add(new Claim("isSysAdmin", "true"));
            }

            //Create Security Token object by giving required parameters    
            var jwtSecurityToken = new JwtSecurityToken(_jwtIssuer, //Issuer    
                            "all",  //Audience    
                            permClaims,
                            expires: null,
                            signingCredentials: credentials);
            var jwtToken = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            return jwtToken;
        }

        public ClaimsPrincipal ValidateSignedJwtToken(string jwt)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtKey));
            
            var handler = new JwtSecurityTokenHandler();
            var validationParameters = new TokenValidationParameters()
            {
                ValidAudience = "all",
                ValidIssuer = _jwtIssuer,
                RequireExpirationTime = false,
                IssuerSigningKey = securityKey,
                ValidateIssuerSigningKey = true
            };

            SecurityToken validatedToken;
            var principal = handler.ValidateToken(jwt, validationParameters, out validatedToken);

            return principal;
        }

        public async Task<User> AuthenticateUserWithToken(Guid guid)
        {
            var now = _systemClock.UtcNow.UtcDateTime;

            var token = await _tokenRepository.GetToken(guid);
            if (token == null)
            {
                //invalid token
                return null;
            }
            else if (now - token.LastRequestAt > new TimeSpan(7,0,0, 0))
            {
                //expired token
                await _tokenRepository.DeleteToken(token);
                return null;
            }
            else
            {
                //valid token
                var user = await _userRepository.GetUser(token.UserId);

                token.LastRequestAt = now;
                await _tokenRepository.UpdateToken(token);

                return user;
            }
        }

        public async Task<User> AuthenticateUserWithPassword(string email, string password)
        {
            var checkUser = await _userRepository.GetUser(email);
            if (checkUser != null)
            {
                if (_passwordService.CheckPassword(checkUser, password))
                {
                    return checkUser;
                }
                else
                {
                    //bad password
                    return null;
                }
            }
            else
            {
                //not found with email
                return null;
            }
        }

        public async Task<User> RegisterUser(string email, string first, string last, string password)
        {
            var user = new User()
            {
                Email = email,
                FirstName = first,
                LastName = last
            };
            _passwordService.SetPassword(user, password);
            await _userRepository.InsertUser(user);
            return user;
        }
        public async Task ChangePassword(User user,string password)
        {
            _passwordService.SetPassword(user, password);
            await _userRepository.UpdateUser(user);
        }

        public async Task<string> IssueJwtToUser(int userId,Guid? existingToken=null,bool minimal=false)
        {
            if (existingToken.HasValue)
            {
                var existing = await _tokenRepository.GetToken(existingToken.Value);
                if (!existing.SupersededAt.HasValue)
                {
                    existing.SupersededAt = _systemClock.UtcNow.UtcDateTime;
                    await _tokenRepository.UpdateToken(existing);
                }
            }

            var user = await _userRepository.GetUser(userId);

            var newToken = await this.CreateNewTokenForUser(user);

            var jwt = this.CreateSignedJwtToken(newToken, (UserIdentifier)user,minimal);

            return jwt;
        }
    }
}
