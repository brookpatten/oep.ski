using NUnit.Framework;
using Amphibian.Oep.Api.Models;
using Amphibian.Oep.Api.Services;
using Amphibian.Oep.Api.Repositories;
using Amphibian.Oep.Api.Dtos;
using AutoMapper;
using Moq;
using Amphibian.Oep.Api.Mappings;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace Amphibian.Oep.Tests.Services
{
    public class UserServiceTests
    {
        private UserService _userService;
        private Mock<IUserRepository> _userRepositoryMock;
        private Mock<IEmailService> _emailServiceMock;
        private Mock<ILogger<UserService>> _loggerMock;
        private IMapper _mapper;

        [SetUp]
        public void Setup()
        {
            _loggerMock = new Mock<ILogger<UserService>>();
            _userRepositoryMock = new Mock<IUserRepository>();
            _emailServiceMock = new Mock<IEmailService>();
            _mapper = DtoMappings.GetMapperConfiguration().CreateMapper();
            _userService = new UserService(_loggerMock.Object, _userRepositoryMock.Object, _emailServiceMock.Object, _mapper);
        }

        
    }
}
