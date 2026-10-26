using SportHub.API.DTOs.Auth;

namespace SportHub.API.Services.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResponse> RegisterAsync(RegisterRequest request);
        Task<AuthResponse> LoginAsync(LoginRequest request);
        Task<UserDto> GetProfileAsync(int userId);
    }
}
