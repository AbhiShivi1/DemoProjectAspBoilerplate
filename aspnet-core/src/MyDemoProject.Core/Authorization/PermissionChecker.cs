using Abp.Authorization;
using MyDemoProject.Authorization.Roles;
using MyDemoProject.Authorization.Users;

namespace MyDemoProject.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
