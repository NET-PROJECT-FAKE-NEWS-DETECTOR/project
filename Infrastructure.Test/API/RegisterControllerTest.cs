using Application.Features.Commands;
using FakeItEasy;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Controllers.v1;
using Xunit;

namespace Persistence.Test.API
{
    public class RegisterControllerTest
    {
        private readonly AdminController controller;
        private readonly IMediator mediator;

        public RegisterControllerTest()
        {
            this.mediator = A.Fake<IMediator>();
            controller = new AdminController(mediator);
        }

        [Fact]
        public async void Given_RegisterController_When_PostIsCalled_Then_ShouldReturnAdmin()
        {
            //Arrange and Act
            CreateAdminAuthCommand admin = new()
            {
                Username = "test1",
                Password = "test2"
            };

            await controller.Register(admin);
            A.CallTo(() => mediator.Send(A<CreateAdminAuthCommand>._, default)).MustHaveHappenedOnceExactly();
        }
    }
}
