using System.Threading.Tasks;
using Abp.Application.Services;
using MyDemoProject.Authorization.Accounts.Dto;

namespace MyDemoProject.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
