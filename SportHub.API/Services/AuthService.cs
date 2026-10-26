using SportHub.API.DTOs.Auth;
using SportHub.API.Entities;
using SportHub.API.Exceptions;
using SportHub.API.Repositories.Interfaces;
using SportHub.API.Services.Interfaces;

namespace SportHub.API.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;

        public AuthService(IUserRepository userRepository, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }
        public async Task<UserDto> GetProfileAsync(int userId)
        {
            var user = await _userRepository.GetByIdAsync(userId)
                    ?? throw new NotFoundException("Không tìm thấy người dùng");

            return ToDto(user);
        }

        public Task<AuthResponse> LoginAsync(LoginRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<AuthResponse> RegisterAsync(RegisterRequest request)
        {
            var email = request.Email.Trim().ToLower();

            if (await _userRepository.EmailExistsAsync(email))
                throw new ConflictException("Email đã được sử dụng");

            var role = await _userRepository.GetRoleByNameAsync(request.Role)
                ?? throw new NotFoundException($"Không tìm thấy vai trò {request.Role}");

            var user = new User
            {
                FullName = request.FullName.Trim(),
                Email = email,
                Phone = request.Phone?.Trim(),
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
                RoleId = role.Id,
                Role = role
            };

            _userRepository.Add(user);
            await _userRepository.SaveChangesAsync();

            return BuildAuthResponse(user);
        }

        private AuthResponse BuildAuthResponse(User user)
        {
            var (token, expiresAt) = _tokenService.CreateToken(user);
            return new AuthResponse(token, expiresAt, ToDto(user));
        }

        private static UserDto ToDto(User u) => new(u.Id, u.FullName, u.Email, u.Phone, u.Role.Name);
    }
}
