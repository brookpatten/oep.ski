using Amphibian.Oep.Api.Dtos;
using Amphibian.Oep.Api.Extensions;
using Amphibian.Oep.Api.Models;
using Amphibian.Oep.Api.Repositories;
using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amphibian.Oep.Api.Services
{
    public class UserService : IUserService
    {
        private ILogger<UserService> _logger;
        private IUserRepository _userRepository;
        private IEmailService _emailService;
        private IMapper _mapper;

        public UserService(ILogger<UserService> logger, IUserRepository userRepository, IEmailService emailService, IMapper mapper)
        {
            _logger = logger;
            _userRepository = userRepository;
            _emailService = emailService;
            _mapper = mapper;
        }

        

        public async Task UpdateUser(UserDto dto)
        {
            var newEmailUser = await _userRepository.GetUser(dto.Email);

            if (newEmailUser == null || newEmailUser.Id == dto.Id)
            {
                var user = await _userRepository.GetUser(dto.Id);
                //user.Email = dto.Email;
                user.FirstName = dto.FirstName;
                user.LastName = dto.LastName;
                await _userRepository.UpdateUser(user);
                //note admins cannot change notification preferences for users, on purpose
            }
            else
            {
                throw new InvalidOperationException("Email in use");
            }
        }

        public async Task RemovePersonalInformation(int userId)
        {
            var user = await _userRepository.GetUser(userId);

            user.FirstName = "Removed";
            user.LastName = "Removed";
            user.NspNumber = null;
            user.PasswordHash = null;
            user.PasswordHashIterations = null;
            user.PasswordSalt = null;
            user.ProfileImageUrl = null;
            user.Email = "Removed-" + Guid.NewGuid() + "@patrol.ski";
            user.AllowEmailNotifications = false;
            await _userRepository.UpdateUser(user);
        }
    }
}