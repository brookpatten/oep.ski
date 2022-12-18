using Amphibian.Oep.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Amphibian.Oep.Api.Repositories
{
    public interface IGlossaryRepository
    {
        Task<IEnumerable<SnowSport>> GetSnowSports();
    }
}
