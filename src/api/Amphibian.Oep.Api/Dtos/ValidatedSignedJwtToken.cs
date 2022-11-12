using Amphibian.Oep.Api.Extensions;
using Amphibian.Oep.Api.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Amphibian.Oep.Api.Dtos
{
    public class ValidatedSignedJwtToken
    {
        public UserIdentifier User { get; set; }
        public Token Token { get; set; }
        public bool? Minimal { get; set; }
        public bool? IsSysAdmin { get; set; }
    }

    public static class ValidatedSignedJwtTokenExtensions
    {
        public static ValidatedSignedJwtToken ParseAllClaims(this ClaimsPrincipal principal)
        {
            if (principal.Claims.Any(x => x.Type == "uid"))
            {
                UserIdentifier user = new UserIdentifier();
                user.Id = int.Parse(principal.Claims.Single(x => x.Type == "uid").Value);

                Token token = new Token();
                token.TokenGuid = Guid.Parse(principal.Claims.Single(x => x.Type == JwtRegisteredClaimNames.Jti).Value);
                token.CreatedAt = long.Parse(principal.Claims.Single(x => x.Type == JwtRegisteredClaimNames.Iat).Value).FromUnixTime();

                bool? minimal = null;
                if (principal.Claims.Any(x => x.Type == "minimal"))
                {
                    minimal = bool.Parse(principal.Claims.Single(x => x.Type == "minimal").Value);
                }

                bool? isSysAdmin = null;
                if (principal.Claims.Any(x => x.Type == "isSysAdmin"))
                {
                    isSysAdmin = bool.Parse(principal.Claims.Single(x => x.Type == "isSysAdmin").Value);
                }

                return new ValidatedSignedJwtToken()
                {
                    User = user,
                    Token = token,
                    Minimal = minimal,
                    IsSysAdmin = isSysAdmin
                };
            }
            else
            {
                return null;
            }
        }

        public static int UserId(this ClaimsPrincipal principal)
        {
            var id = principal.ParseAllClaims().User.Id;
            return id;
        }

        public static Guid TokenGuid(this ClaimsPrincipal principal)
        {
            var id = principal.ParseAllClaims().Token.TokenGuid;
            return id;
        }
    }
}
