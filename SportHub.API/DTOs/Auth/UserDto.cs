namespace SportHub.API.DTOs.Auth
{
    public record UserDto(int Id, string FullName, string Email, string? Phone, string Role);
}
