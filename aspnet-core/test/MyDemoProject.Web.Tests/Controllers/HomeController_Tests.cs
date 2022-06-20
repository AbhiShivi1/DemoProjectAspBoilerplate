using System.Threading.Tasks;
using MyDemoProject.Models.TokenAuth;
using MyDemoProject.Web.Controllers;
using Shouldly;
using Xunit;

namespace MyDemoProject.Web.Tests.Controllers
{
    public class HomeController_Tests: MyDemoProjectWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}