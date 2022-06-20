using Abp.Application.Services;
using Abp.Domain.Repositories;
using MyDemoProject.Services.AddPatient.DtoPatient;
using System;
using System.Threading.Tasks;

namespace MyDemoProject.Services.AddPatient
{
    public class AddPatientService : CrudAppService<PatientDetails, PatientDetailsDto>
    {
        private readonly IRepository<PatientDetails, int> _repository;

        public AddPatientService(IRepository<PatientDetails, int> repository) : base(repository)
        {
            _repository = repository;
        }

        public string GetAddPatientInvitationLink(String TherapistId)
        {
            var URl = "https://PatientApp/Registration.com"+"?TherapistId="+TherapistId;
            return URl;

        }

        public async Task<PatientDetails> PostData(PatientDetails add)
        {
            
            var addPatient = new PatientDetails()
            {
                FirstName = add.FirstName,
                LastName = add.LastName,
                Email = add.Email,
                PhoneNumber = add.PhoneNumber,
            };
            _repository.Insert(addPatient);
            //if Email present then send mail to that email entered with link to register along with ID
            //if Email not present then send text to the phn number with link to register along with ID
            return addPatient;
        }

    }
}
