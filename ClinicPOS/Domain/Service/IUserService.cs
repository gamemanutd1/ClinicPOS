using ClinicPOS.Application.Model.Request;
using ClinicPOS.Application.Model.Response;

namespace ClinicPOS.Domain.Service
{
    public interface IUserService
    {
        Task<LoginDTO> LoginAsync(string username, string password);
        Task CreateUserAsync(CreateUserRequest request);
        Task UpdateUserAsync(Guid id, UpdateUserRequest request);
        Task<List<UserDTO>> GetAllUserAsync();
    }
}
