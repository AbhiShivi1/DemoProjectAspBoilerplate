using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDemoProject.Services.AddPatient.DtoPatient
{
    public class PatientDetails:Entity<int> , IValidatableObject
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
