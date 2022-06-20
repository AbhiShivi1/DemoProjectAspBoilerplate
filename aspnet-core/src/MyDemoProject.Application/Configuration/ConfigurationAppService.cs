using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using MyDemoProject.Configuration.Dto;

namespace MyDemoProject.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : MyDemoProjectAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
