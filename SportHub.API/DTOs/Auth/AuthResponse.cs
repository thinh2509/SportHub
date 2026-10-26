namespace SportHub.API.DTOs.Auth
{
    public record AuthResponse(string AccessToken, DateTime ExpiresAt, UserDto User);
}
