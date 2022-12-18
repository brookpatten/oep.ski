using Amphibian.Oep.Api.Models;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;
using Dommel;
using Dapper;

namespace Amphibian.Oep.Api.Repositories
{
    public class VideoRepository : IVideoRepository
    {
        private readonly DbConnection _connection;

        public VideoRepository(DbConnection connection)
        {
            _connection = connection;
        }

        public async Task<IEnumerable<Video>> GetPopularVideos(int snowsportId, int count)
        {
            var videos = await _connection.QueryAsync<Video>("select top (@count) * from videos where snowsportid in @snowsportId order by createdat desc", new { snowsportId,count });
            return videos;
        }

        public async Task<IEnumerable<Video>> GetRecentVideos(int snowsportId, int count)
        {
            var videos = await _connection.QueryAsync<Video>(@"select top (@count) 
	            v.id
	            ,v.videoprovider
	            ,v.videoproviderkey
	            ,v.title
	            ,v.createdbyuserid
	            ,v.createdat
	            ,v.snowsportid
	            ,count(r.id) as responsecount
            from videos v
            left join responses r on r.videoid=v.id
            where snowsportid=@snowsportId
            group by v.id,v.videoprovider,v.videoproviderkey,v.title,v.createdbyuserid,v.createdat,v.snowsportid
            order by count(r.id) desc", new { snowsportId, count });
            return videos;
        }
    }
}
