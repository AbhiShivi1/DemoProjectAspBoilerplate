using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MyDemoProject.Services.Users.UserDto
{
    public class Auth0SignUpDetails
    {
        [Required]
        [JsonPropertyName("client_id")]
        public string ClientId { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        public Connection Connection { get; set; }
    }
    public enum Connection
    {
        TherapAreaDB, MyDemoProjectDb
    }
    
}


