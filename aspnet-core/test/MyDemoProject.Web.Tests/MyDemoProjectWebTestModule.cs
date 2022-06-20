using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using MyDemoProject.EntityFrameworkCore;
using MyDemoProject.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace MyDemoProject.Web.Tests
{
    [DependsOn(
        typeof(MyDemoProjectWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class MyDemoProjectWebTestModule : AbpModule
    {
        public MyDemoProjectWebTestModule(MyDemoProjectEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MyDemoProjectWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(MyDemoProjectWebMvcModule).Assembly);
        }
    }
}