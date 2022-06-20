using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using MyDemoProject.Authorization;

namespace MyDemoProject
{
    [DependsOn(
        typeof(MyDemoProjectCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class MyDemoProjectApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<MyDemoProjectAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(MyDemoProjectApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
