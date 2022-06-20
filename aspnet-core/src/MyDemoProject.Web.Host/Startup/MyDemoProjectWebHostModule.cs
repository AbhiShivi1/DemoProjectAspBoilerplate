using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using MyDemoProject.Configuration;

namespace MyDemoProject.Web.Host.Startup
{
    [DependsOn(
       typeof(MyDemoProjectWebCoreModule))]
    public class MyDemoProjectWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public MyDemoProjectWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MyDemoProjectWebHostModule).GetAssembly());
        }
    }
}
