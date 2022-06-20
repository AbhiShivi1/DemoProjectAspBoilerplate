using Abp.Domain.Entities;
using System;

namespace MyDemoProject.Models
{
    public class UserDetails :Entity<int>
    {
      //  public int Id { get; set; }
        public string Auth0Id { get; set; }
        public string UniqueCode { get; set; }
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
