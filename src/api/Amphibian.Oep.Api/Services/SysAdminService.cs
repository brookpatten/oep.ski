using Amphibian.Oep.Api.Models;
using Amphibian.Oep.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amphibian.Oep.Api.Services
{
    public class SysAdminService : ISysAdminService
    {
        public string[] _systemAdministrators;

        public SysAdminService(AppConfiguration configuration)
        {
            _systemAdministrators = configuration.SystemAdministrators;
        }
        public bool IsUserSysAdmin(UserIdentifier user)
        {
            return _systemAdministrators.Any(x => x.ToLower() == user.Email.ToLower());
        }
    }
}
