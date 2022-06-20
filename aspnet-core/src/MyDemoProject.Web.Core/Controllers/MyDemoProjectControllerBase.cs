using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace MyDemoProject.Controllers
{
    public abstract class MyDemoProjectControllerBase: AbpController
    {
        protected MyDemoProjectControllerBase()
        {
            LocalizationSourceName = MyDemoProjectConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
