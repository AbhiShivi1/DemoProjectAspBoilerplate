using Abp.Domain.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyDemoProject.Models
{
    public class PatientInvitation:Entity<int>, IValidatableObject
    {
       // public int Id { get; set; }
        public int TherapistId { get; set; }
        public int PatientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public Status Status { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Email == null && PhoneNumber == null)
                yield return new ValidationResult("Either Email or PhoneNumber  must be specified");
        }
    }
    public enum Status
    {
        Pending,Approved,Rejected
    }
}
