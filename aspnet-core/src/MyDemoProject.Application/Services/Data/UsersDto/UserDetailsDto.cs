using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using MyDemoProject.Models;
using System;

namespace MyDemoProject.Services.Data.UsersDto
{
    [AutoMapFrom(typeof(UserDetails))]
    public class UserDetailsDto:EntityDto<int>
    {
        public string Auth0Id { get; set; }
        public string UniqueCode { get; set; } = Guid.NewGuid().ToString("N").Substring(0, 6);
        public string Type { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneCode { get; set; }
        public string PhoneNumber { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public int ZipCode { get; set; }
        public string Currency { get; set; }
        public string Language { get; set; }
    }
}
