using System.ComponentModel.DataAnnotations;

namespace MyDemoProject.Services.UserDto
{
    public class UserBase
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string PhoneCode { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string Language { get; set; }
    }
}
//{
//    "client_id": "uCwHAKIQ9Dn0SJIoeWnljTFEA9pBhzfO",
//  "email": "rahmatali@promactinfo.com",
//  "password": "Abhinav123",
//  "connection": "MyDemoProjectDB",
//  "firstName": "Rahmat",
//  "lastName": "Ali",
//  "phoneCode": "+91",
//  "phoneNumber": "1234567899",
//  "street": "picnic",
//  "language": "English",
//  "title": "Mr",
//  "city": "Lucknow",
//  "country": "India",
//  "zipCode": 226010,
//  "currency": "Rupees"
//}
