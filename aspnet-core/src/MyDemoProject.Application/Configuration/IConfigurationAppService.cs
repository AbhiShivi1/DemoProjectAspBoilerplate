using System.Threading.Tasks;
using MyDemoProject.Configuration.Dto;

namespace MyDemoProject.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
