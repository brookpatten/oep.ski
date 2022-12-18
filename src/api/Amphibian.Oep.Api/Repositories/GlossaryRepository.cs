using Amphibian.Oep.Api.Models;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;
using Dommel;
using Dapper;

namespace Amphibian.Oep.Api.Repositories
{
    public class GlossaryRepository : IGlossaryRepository
    {
        private readonly DbConnection _connection;

        public GlossaryRepository(DbConnection connection)
        {
            _connection = connection;
        }

        public Task<IEnumerable<SnowSport>> GetSnowSports()
        {
            return _connection.GetAllAsync<SnowSport>();
        }
    }
}
