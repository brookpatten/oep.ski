using Amphibian.Oep.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Amphibian.Oep.Api.Repositories
{
    public interface IResponseRepository
    {
        Task<IEnumerable<Response>> GetRecentResponses(int snowsportId, int count);
        Task<IEnumerable<Response>> GetPopularResponses(int snowsportId, int count);
    }
}
