using Amphibian.Oep.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amphibian.Oep.Api.Services
{
    public interface ISysAdminService
    {
        public bool IsUserSysAdmin(UserIdentifier user);
    }
}
