using Amphibian.Oep.Api.Models;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Amphibian.Oep.Api.Repositories
{
    public interface IFileUploadRepository
    {
        Task InsertImageUpload(FileUpload upload);
        Task<FileUpload> PersistUpload(IFormFile upload, int userId, int? patrolId);
    }
}