using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using MyDemoProject.Models;

namespace MyDemoProject.Services.Data
{
    [AutoMapFrom(typeof(TherapistPatientMapping))]
    public class TherapistPatientMappingDto:EntityDto<int>
    {
        public int TherapistId { get; set; }
        public int PatientId { get; set; }
    }
}
