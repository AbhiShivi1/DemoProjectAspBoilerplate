using Abp.Domain.Entities;

namespace MyDemoProject.Models
{
    public class TherapistPatientMapping:Entity<int>
    {
       // public int Id { get; set; }
        public int TherapistId { get; set; }
        public int PatientId { get; set; }
    }
}
