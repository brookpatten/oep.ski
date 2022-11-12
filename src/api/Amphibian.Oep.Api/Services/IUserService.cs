using Amphibian.Oep.Api.Dtos;
using Amphibian.Oep.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amphibian.Oep.Api.Services
{
    public interface IUserService
    {
        Task UpdateUser(UserDto dto);
        Task RemovePersonalInformation(int userId);
    }
}
