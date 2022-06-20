using System.Threading.Tasks;
using Abp.Application.Services;
using MyDemoProject.Sessions.Dto;

namespace MyDemoProject.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
