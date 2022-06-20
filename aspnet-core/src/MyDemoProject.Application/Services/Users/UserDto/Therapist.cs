using System.ComponentModel.DataAnnotations;

namespace MyDemoProject.Services.UserDto
{
    public class Therapist :UserBase
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public int ZipCode { get; set; }
        [Required]
        public string Currency { get; set; }
    }
}
