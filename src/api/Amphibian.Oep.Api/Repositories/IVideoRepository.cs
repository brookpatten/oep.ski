using Amphibian.Oep.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Amphibian.Oep.Api.Repositories
{
    public interface IVideoRepository
    {
        Task<IEnumerable<Video>> GetRecentVideos(int snowsportId, int count);
        Task<IEnumerable<Video>> GetPopularVideos(int snowsportId, int count);
    }
}
