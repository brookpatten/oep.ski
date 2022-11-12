using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Data;
using Dapper;
using Dommel;

using Amphibian.Oep.Api.Models;
using System.Data.Common;
using Amphibian.Oep.Api.Extensions;

namespace Amphibian.Oep.Api.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DbConnection _connection;

        public UserRepository(DbConnection connection)
        {
            _connection = connection;
        }

        public async Task InsertUser(User user)
        {
            user.Id = (int)await _connection.InsertAsync(user).ConfigureAwait(false).ToInt32();
        }

        public async Task UpdateUser(User user)
        {
            await _connection.UpdateAsync(user).ConfigureAwait(false);
        }

        public async Task<User> GetUser(int id)
        {
            var user = await _connection.GetAsync<User>(id).ConfigureAwait(false);
            return user;
        }

        public async Task<IEnumerable<User>> GetUsers(IList<int> userIds)
        {
            var users = await _connection.QueryAsync<User>("select * from users where id in @userIds", new { userIds });
            return users;
        }

        public async Task<User> GetUser(string email)
        {
            var users = await _connection.SelectAsync<User>(x => x.Email == email);
            if(users.Any())
            {
                return users.First();
            }
            else
            {
                return null;
            }
        }

        public async Task<IEnumerable<User>> GetUsersToCleanup()
        {
            return await _connection.QueryAsync<User>(@"
            select u.id,u.email
            from users u
            left join patrolusers pu on pu.userid=u.id
            where u.email like '%@patrol.ski'
            group by u.id,u.email
            having count(pu.id)=0")
                .ConfigureAwait(false);
        }

        public async Task DeleteUsers(IList<int> userIds)
        {
            await _connection.ExecuteAsync(@"delete from users where id in @userIds", new { userIds })
                .ConfigureAwait(false);
        }
    }
}
