using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authentication;
using Moq;
using Amphibian.Oep.Api.Models;
using Amphibian.Oep.Api.Services;
using Amphibian.Oep.Api.Repositories;
using AuthenticationService = Amphibian.Oep.Api.Services.AuthenticationService;
using Amphibian.Oep.Api.Dtos;
using System.Linq;
using Microsoft.IdentityModel.Tokens;

namespace Amphibian.Oep.Tests.Services
{
    [TestFixture(Category = "Services")]
    public class AuthenticationServiceTests
    {
        private AuthenticationService _authenticationService;
        private Mock<IUserRepository> _userRepositoryMock;
        private Mock<ITokenRepository> _tokenRepositoryMock;
        private Mock<IPasswordService> _passwordServiceMock;
        private Mock<ILogger<AuthenticationService>> _loggerMock;
        private Mock<ISystemClock> _systemClockMock;
        private Mock<ISysAdminService> _sysAdminService;

        [SetUp]
        public void Setup()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
            _tokenRepositoryMock = new Mock<ITokenRepository>();
            _passwordServiceMock = new Mock<IPasswordService>();
            _loggerMock = new Mock<ILogger<AuthenticationService>>();
            _systemClockMock = new Mock<ISystemClock>();
            _sysAdminService = new Mock<ISysAdminService>();
            _authenticationService = new AuthenticationService(_loggerMock.Object, _userRepositoryMock.Object, _passwordServiceMock.Object, 
                _tokenRepositoryMock.Object, _systemClockMock.Object,
                new Configuration.AppConfiguration() { JwtKey = "jwtKeyjwtKeyjwtKeyjwtKeyjwtKey", RootUrl = "jwtIssuer" }, _sysAdminService.Object);
        }

        [Test]
        public async Task CreateNewTokenForUserShouldInsertToTable()
        {
            var user = new User()
            {
                Id = 1
            };

            _tokenRepositoryMock.Setup(x => x.InsertToken(It.Is<Token>(p => p.UserId == user.Id && p.TokenGuid != default(Guid))))
                .Returns(Task.FromResult(new Token() { Id = 1, UserId = user.Id }))
                .Verifiable();

            await _authenticationService.CreateNewTokenForUser(user);

            
            _tokenRepositoryMock.Verify();
        }

        [Test]
        public async Task AuthenticateUserWithInvalidTokenReturnsNull()
        {
            Guid id = Guid.NewGuid();

            _tokenRepositoryMock.Setup(x => x.GetToken(id))
                .Returns(Task.FromResult((Token)null))
                .Verifiable();

            var user = await _authenticationService.AuthenticateUserWithToken(id);


            _tokenRepositoryMock.Verify();
            Assert.IsNull(user);
        }

        [Test]
        public async Task AuthenticateUserWithExpiredTokenReturnsNullAndDeletesToken()
        {
            Guid id = Guid.NewGuid();
            var token = new Token()
            {
                Id = 1,
                TokenGuid = id,
                CreatedAt = new DateTime(2020, 1, 1, 1, 0, 0),
                LastRequestAt = new DateTime(2020, 1, 1, 1, 0, 0),
                UserId = 1
            };

            _systemClockMock.Setup(x => x.UtcNow)
                .Returns(new DateTimeOffset(new DateTime(2020,1,10,3,0,0)))
                .Verifiable();

            _tokenRepositoryMock.Setup(x => x.GetToken(id))
                .Returns(Task.FromResult(token))
                .Verifiable();

            _tokenRepositoryMock.Setup(x => x.DeleteToken(token)).Verifiable();

            var user = await _authenticationService.AuthenticateUserWithToken(id);

            _systemClockMock.Verify();
            _tokenRepositoryMock.Verify();
            Assert.IsNull(user);
        }

        [Test]
        public async Task AuthenticateUserWithValidTokenUpdatesTokenAndReturnsUser()
        {
            Guid id = Guid.NewGuid();
            var token = new Token()
            {
                Id = 1,
                TokenGuid = id,
                CreatedAt = new DateTime(2020, 1, 1, 1, 0, 0),
                LastRequestAt = new DateTime(2020, 1, 1, 1, 0, 0),
                UserId = 1
            };

            var user = new User()
            {
                Id = 1,
                Email = "Email",
                FirstName = "FirstName",
                LastName = "LastName"
            };

            _systemClockMock.Setup(x => x.UtcNow)
                .Returns(new DateTimeOffset(new DateTime(2020, 1, 1, 1, 1, 0,DateTimeKind.Utc)))
                .Verifiable();

            _tokenRepositoryMock.Setup(x => x.GetToken(id))
                .Returns(Task.FromResult(token))
                .Verifiable();

            _tokenRepositoryMock.Setup(x => x.DeleteToken(token))
                .Throws(new Exception("Should not delete a valid token"));

            _tokenRepositoryMock.Setup(x => x.UpdateToken(token))
                .Verifiable();

            _userRepositoryMock.Setup(x => x.GetUser(token.UserId))
                .Returns(Task.FromResult(user))
                .Verifiable();

            var resultUser = await _authenticationService.AuthenticateUserWithToken(id);

            _tokenRepositoryMock.Verify();
            _userRepositoryMock.Verify();
            _systemClockMock.Verify();
            Assert.AreEqual(user, resultUser);
        }

        [Test]
        public async Task AuthenticateUserWithPasswordReturnsNullIfUserIsMissing()
        {
            var user = new User()
            {
                Id = 1,
                Email = "Email",
                FirstName = "FirstName",
                LastName = "LastName"
            };

            _userRepositoryMock.Setup(x => x.GetUser(user.Email))
                .Returns(Task.FromResult((User)null))
                .Verifiable();

            var resultUser = await _authenticationService.AuthenticateUserWithPassword(user.Email, "any");

            _userRepositoryMock.Verify();
            Assert.IsNull(resultUser);
        }

        [Test]
        public async Task AuthenticateUserWithPasswordReturnsNullIfPasswordIsWrong()
        {
            var user = new User()
            {
                Id = 1,
                Email = "Email",
                FirstName = "FirstName",
                LastName = "LastName"
            };

            _userRepositoryMock.Setup(x => x.GetUser(user.Email))
                .Returns(Task.FromResult(user))
                .Verifiable();

            _passwordServiceMock.Setup(x => x.CheckPassword(user, It.IsAny<string>()))
                .Returns(false)
                .Verifiable();

            var resultUser = await _authenticationService.AuthenticateUserWithPassword(user.Email, "any");

            _userRepositoryMock.Verify();
            _passwordServiceMock.Verify();
            Assert.IsNull(resultUser);
        }

        [Test]
        public async Task AuthenticateUserWithPasswordReturnsUserIfPasswordIsCorrect()
        {
            var user = new User()
            {
                Id = 1,
                Email = "Email",
                FirstName = "FirstName",
                LastName = "LastName"
            };

            _userRepositoryMock.Setup(x => x.GetUser(user.Email))
                .Returns(Task.FromResult(user))
                .Verifiable();

            _passwordServiceMock.Setup(x => x.CheckPassword(user, It.IsAny<string>()))
                .Returns(true)
                .Verifiable();

            var resultUser = await _authenticationService.AuthenticateUserWithPassword(user.Email, "any");

            _userRepositoryMock.Verify();
            _passwordServiceMock.Verify();
            Assert.AreEqual(user, resultUser);
        }

        [Test]
        public void CanCreateSignedJwtToken()
        {
            var user = new User()
            {
                Id = 1,
            };
            var token = new Token()
            {
                Id = 1,
                CreatedAt = new DateTime(2001, 1, 1),
                TokenGuid = Guid.NewGuid(),
                UserId = user.Id
            };
            

            var jwt = _authenticationService.CreateSignedJwtToken(token, user);

            Assert.NotNull(jwt);
        }

        [Test]
        public void CanVerifySignedJwtToken()
        {
            var user = new User()
            {
                Id = 1,
            };
            var token = new Token()
            {
                CreatedAt = new DateTime(2001, 1, 1),
                TokenGuid = Guid.NewGuid(),
                UserId = user.Id
            };
            
            var jwt = _authenticationService.CreateSignedJwtToken(token, user);

            var claimsPrincipal = _authenticationService.ValidateSignedJwtToken(jwt);

            var claims = claimsPrincipal.ParseAllClaims();

            Assert.AreEqual(user.Id, claims.User.Id);
            Assert.AreEqual(token.TokenGuid, claims.Token.TokenGuid);
            Assert.AreEqual(token.CreatedAt, claims.Token.CreatedAt);
            
        }

        [Test]
        public void CannotVerifyWithIncorrectKey()
        {
            var user = new User()
            {
                Id = 1,
            };
            var token = new Token()
            {
                CreatedAt = new DateTime(2001, 1, 1),
                TokenGuid = Guid.NewGuid(),
                UserId = user.Id
            };
            
            var jwt = _authenticationService.CreateSignedJwtToken(token, user);

            var incorrectAuthenticationService = new AuthenticationService(_loggerMock.Object, _userRepositoryMock.Object, _passwordServiceMock.Object, 
                _tokenRepositoryMock.Object, _systemClockMock.Object,
                new Configuration.AppConfiguration() { JwtKey = "incorrectJwtKeyincorrectJwtKeyincorrectJwtKey", RootUrl = "jwtIssuer" }, _sysAdminService.Object);

            Assert.Throws<SecurityTokenSignatureKeyNotFoundException>(() =>
            {
                var validatedJwt = incorrectAuthenticationService.ValidateSignedJwtToken(jwt);
            });
        }

        [Test]
        public void CannotVerifyWithIncorrectSignature()
        {
            var user = new User()
            {
                Id = 1,
            };
            var token = new Token()
            {
                CreatedAt = new DateTime(2001, 1, 1),
                TokenGuid = Guid.NewGuid(),
                UserId = user.Id
            };
            

            var jwt = _authenticationService.CreateSignedJwtToken(token, user);

            string incorrect = "XXXXXXXXXXhzfsEP2rak1meCXJbAsiH0-8dyA4xmDWY";

            var sigIndex = jwt.LastIndexOf(".")+1;

            var wrongJwt = jwt.Substring(0, sigIndex) + incorrect;


            Assert.Throws<SecurityTokenSignatureKeyNotFoundException>(() =>
            {
                var validatedJwt = _authenticationService.ValidateSignedJwtToken(wrongJwt);
            });
        }
    }
}
