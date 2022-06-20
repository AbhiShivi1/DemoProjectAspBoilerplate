using System.ComponentModel.DataAnnotations;

namespace MyDemoProject.Services.UserDto
{
    public class Patient:UserBase
    {
        [Required]
        public string Address { get; set; }
        public Therapist Therapist { get; set; }
    }
}
