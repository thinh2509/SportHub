using System.ComponentModel.DataAnnotations;

namespace SportHub.API.DTOs.SportTypes
{
    public class SportTypeRequest
    {
        [Required(ErrorMessage = "Tên môn thể thao không được để trống")]
        [MaxLength(50, ErrorMessage = "Tên môn thể thao tối đa 50 ký tự")]
        public string Name { get; set; } = string.Empty;
    }
}
