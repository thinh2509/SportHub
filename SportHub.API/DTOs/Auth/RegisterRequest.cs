using System.ComponentModel.DataAnnotations;

namespace SportHub.API.DTOs.Auth
{
    public class RegisterRequest
    {
        [Required(ErrorMessage = "Họ tên không được để trống")]
        [MaxLength(100, ErrorMessage = "Họ tên tối đa 100 ký tự")]
        public string FullName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email không được để trống")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        [MaxLength(100)]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        [MinLength(6, ErrorMessage = "Mật khẩu tối thiểu 6 ký tự")]
        [MaxLength(100)]
        public string Password { get; set; } = string.Empty;

        [Phone(ErrorMessage = "Số điện thoại không hợp lệ")]
        [MaxLength(15)]
        public string? Phone { get; set; }

        [Required]
        [RegularExpression("^(Customer|Owner)$", ErrorMessage = "Vai trò chỉ được là Customer hoặc Owner")]
        public string Role { get; set; } = "Customer";
    }
}
