using Abp.Zero.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyDemoProject.Authorization.Roles;
using MyDemoProject.Authorization.Users;
using MyDemoProject.Models;
using MyDemoProject.MultiTenancy;
using MyDemoProject.Services.AddPatient.DtoPatient;

namespace MyDemoProject.EntityFrameworkCore
{
    public class MyDemoProjectDbContext : AbpZeroDbContext<Tenant, Role, User, MyDemoProjectDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public MyDemoProjectDbContext(DbContextOptions<MyDemoProjectDbContext> options)
            : base(options)
        {
        }
        public DbSet<PatientDetails> PatientDetails { get; set; }
        public DbSet<UserDetails> User { get; set; }
        public DbSet<TherapistPatientMapping> TherapistPatientMapping { get; set; }
        public DbSet<PatientInvitation> PatientInvitation { get; set; }
    }
}
