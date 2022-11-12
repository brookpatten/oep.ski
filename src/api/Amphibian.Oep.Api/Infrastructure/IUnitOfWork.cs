using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amphibian.Oep.Api.Infrastructure
{
    public interface IUnitOfWork
    {
        Task Begin();
        Task Commit();
        Task Rollback();
    }
}
