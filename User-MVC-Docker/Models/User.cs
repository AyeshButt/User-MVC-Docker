using System.ComponentModel.DataAnnotations;

namespace User_MVC_Docker.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Email { get; set; } = string.Empty;
        public int PhoneNumber { get; set; }
        public string Country { get; set; } = string.Empty;
    }
}
