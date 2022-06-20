using System.ComponentModel.DataAnnotations;

namespace MyDemoProject.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}