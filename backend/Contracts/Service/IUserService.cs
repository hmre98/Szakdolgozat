using backend.DTOs;

namespace backend.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> GetUsers(PaginationDTO pagination);
        Task<AuthenticationResponseDTO> Register(UserCredentialsDTO userCredentials);
        Task<AuthenticationResponseDTO?> Login(UserLoginDTO userCredentials);
        Task MakeAdmin(string email);
        Task RemoveAdmin(string email);
    }
}
