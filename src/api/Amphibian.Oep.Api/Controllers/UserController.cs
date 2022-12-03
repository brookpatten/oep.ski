using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Amphibian.Oep.Api.Repositories;
using Amphibian.Oep.Api.Models;
using Amphibian.Oep.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Amphibian.Oep.Api.Extensions;
using Amphibian.Oep.Api.Dtos;
using Microsoft.Extensions.Logging;
using Amphibian.Oep.Api.Infrastructure;
using Microsoft.AspNetCore.Authentication;
using AutoMapper;
using CsvHelper;
using System.IO;
using System.Globalization;
using System.Net.Http.Headers;
using CsvHelper.Configuration;
using System.Linq.Expressions;

namespace Amphibian.Oep.Api.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private IUserService _userService;
        private IUserRepository _userRepository;
        private Services.IAuthenticationService _authenticationService;
        private ITokenRepository _tokenRepository;
        private ISystemClock _systemClock;
        private IMapper _mapper;
        

        public UserController(ILogger<UserController> logger,IUserRepository userRepository,IEmailService emailService
             ,IUserService userService
            , Services.IAuthenticationService authenticationService, ITokenRepository tokenRepository, ISystemClock systemClock, 
            IMapper mapper)
        {
            _logger = logger;
            _userService = userService;
            _userRepository = userRepository;
            _authenticationService = authenticationService;
            _tokenRepository = tokenRepository;
            _systemClock = systemClock;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("user/list")]
        [Authorize]
        public async Task<IActionResult> List()
        {
            //if ()
            //{
            //    var users = await _userService.GetUsers(patrolId);
            //    return Ok(users);
            //}
            //else
            //{
                return Forbid();
            //}
        }

        [HttpGet]
        [Route("user/{userId}")]
        [Authorize]
        public async Task<IActionResult> Get(int patrolId, int userId)
        {
            //if ()
            //{
            //    var user = await _userService.GetPatrolUser(patrolId,userId);
            //    return Ok(user);
            //}
            //else
            //{
                return Forbid();
            //}
        }

        [HttpGet]
        [Route("user")]
        [Authorize]
        public async Task<IActionResult> GetSelf()
        {
            var user = await _userRepository.GetUser(User.UserId());
            var id = _mapper.Map<User, UserIdentifier>(user);

            return Ok(id);
        }

        /// <summary>
        /// delete yourself and all your personal information
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        [Route("user")]
        [Authorize]
        [UnitOfWork]
        public async Task<IActionResult> Delete()
        {
            await _userService.RemovePersonalInformation(User.UserId());

            Response.SendNewToken("Deleted");

            return Ok();
        }

        [HttpPut]
        [Route("user")]
        [Authorize]
        [UnitOfWork]
        public async Task<IActionResult> Save(UserDto dto)
        {
            //users can update some things themselves
            if(dto.Id == User.UserId())
            {
                var newEmailUser = await _userRepository.GetUser(dto.Email);

                if (newEmailUser == null || newEmailUser.Id == dto.Id)
                {
                    var user = await _userRepository.GetUser(dto.Id);

                    user.FirstName = dto.FirstName;
                    user.LastName = dto.LastName;
                    //user.Email = dto.Email;
                    user.AllowEmailNotifications = dto.AllowEmailNotifications;
                    user.ProfileImageUrl = dto.ProfileImageUrl;
                    await _userRepository.UpdateUser(user);
                }
                else
                {
                    throw new InvalidOperationException("Email in use");
                }
                return Ok();
            }
            else
            {
                return Forbid();
            }
        }
    }
}