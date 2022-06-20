using Abp.Application.Services;
using MyDemoProject.MultiTenancy.Dto;

namespace MyDemoProject.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

