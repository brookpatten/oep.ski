using Amphibian.Oep.Api.Models;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Amphibian.Oep.Api.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUser(int id);
        Task<IEnumerable<User>> GetUsers(IList<int> ids);
        Task<User> GetUser(string email);
        Task InsertUser(User user);
        Task UpdateUser(User user);
        Task DeleteUsers(IList<int> userIds);
        Task<IEnumerable<User>> GetUsersToCleanup();
    }
}