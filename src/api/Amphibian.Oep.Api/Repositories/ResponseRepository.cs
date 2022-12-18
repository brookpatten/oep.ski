using Amphibian.Oep.Api.Models;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;
using Dommel;
using Dapper;

namespace Amphibian.Oep.Api.Repositories
{
    public class ResponseRepository : IResponseRepository
    {
        private readonly DbConnection _connection;

        public ResponseRepository(DbConnection connection)
        {
            _connection = connection;
        }

        public async Task<IEnumerable<Response>> GetPopularResponses(int snowsportId, int count)
        {
            var responses = await _connection.QueryAsync<Response>(@"
                select
                top (@count) 
                    r.id
                    ,r.createdbyuserid
                    ,r.createdat
                    ,r.updatedat
                    ,r.videoid
                    ,r.comments
                    ,sum(case when f.thumbsup=1 then 1 else 0 end) as score
                from responses r
                inner join videos v on 
                    v.id=r.videoid 
                    and v.SnowSportId=@snowsportId
                left join feedbacks f on 
                    f.responseid=r.id
                group by 
                    r.id
                    ,r.createdbyuserid
                    ,r.createdat
                    ,r.updatedat
                    ,r.videoid
                    ,r.comments
                order by sum(case when f.thumbsup=1 then 1 else 0 end) desc", new { snowsportId, count });
            return responses;
        }

        public async Task<IEnumerable<Response>> GetRecentResponses(int snowsportId, int count)
        {
            var responses = await _connection.QueryAsync<Response>(@"
                select 
                    top (@count) 
                    r.id
                    ,r.createdbyuserid
                    ,r.createdat
                    ,r.updatedat
                    ,r.videoid
                    ,r.comments
                    ,sum(case when f.thumbsup=1 then 1 else 0 end) as score
                from responses r
                inner join videos v on 
                    v.id=r.videoid 
                    and v.SnowSportId=@snowsportId
                left join feedbacks f on 
                    f.responseid=r.id
                group by 
                    r.id
                    ,r.createdbyuserid
                    ,r.createdat
                    ,r.updatedat
                    ,r.videoid
                    ,r.comments
                order by r.createdat desc", new { snowsportId, count });
            return responses;
        }
    }
}
