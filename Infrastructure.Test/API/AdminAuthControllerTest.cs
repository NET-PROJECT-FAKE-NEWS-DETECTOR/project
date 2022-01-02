using Application.Features.Queries;
using FakeItEasy;
using MediatR;
using WebAPI.Controllers.v1;
using Xunit;

namespace Persistence.Test.API
{
    public class AdminAuthControllerTest
    {
        private readonly AdminAuthController controller;
        private readonly IMediator mediator;

        public AdminAuthControllerTest()
        {
            this.mediator = A.Fake<IMediator>();
            controller = new AdminAuthController(mediator);
        }

        [Fact]
        public async void Given_AdminAuthController_When_GetIsCalled_Then_ShouldReturnAdmin()
        {
            //Arrange and Act

            await controller.GetAdminInfo("adminTest2");
            A.CallTo(() => mediator.Send(A<GetAdminAuthByUsernameQuery>._, default)).MustHaveHappenedOnceExactly();
        }

    }
}
