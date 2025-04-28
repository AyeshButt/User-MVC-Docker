using System.ComponentModel.DataAnnotations;

namespace User_MVC_Docker.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Name is required")]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "Age is required")]
        public int Age { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress,ErrorMessage ="Invalid email")]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "Phone number is required")]
        public int PhoneNumber { get; set; }
        [Required(ErrorMessage = "Country is required")]
        public string Country { get; set; } = string.Empty;

    }
}
