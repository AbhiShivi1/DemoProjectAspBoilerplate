using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyDemoProject.Services.AddPatient.DtoPatient
{
    [AutoMapFrom(typeof(PatientDetails))]
    public class PatientDetailsDto:EntityDto<int> , IValidatableObject
    {
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Email == null && PhoneNumber == null)
                yield return new ValidationResult("Either Email or PhoneNumber  must be specified");
        }
    }
}
