using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using MyDemoProject.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyDemoProject.Services.Data
{
    [AutoMapFrom(typeof(PatientInvitation))]
    public class PatientInvitationDto:EntityDto<int>, IValidatableObject
    {
        public int TherapistId { get; set; }
        public int PatientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Email == null && PhoneNumber == null)
                yield return new ValidationResult("Either Email or PhoneNumber  must be specified");
        }
    }
}
