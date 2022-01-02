using Application.Features.Queries;
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
    public class GetTrueOrFakeInfoControllerTest
    {
        private readonly AdminController controller;
        private readonly IMediator mediator;

        public GetTrueOrFakeInfoControllerTest()
        {
            this.mediator = A.Fake<IMediator>();
            controller = new AdminController(mediator);
        }

        [Fact]
        public async void Given_GetTrueInfoController_When_GetIsCalled_Then_ShouldReturnADataSetCollection()
        {
            //Arrange and Act
            var validation = true;
            await controller.GetTrueInfo(validation);
            A.CallTo(() => mediator.Send(A<GetDataSetByValidationQuery>._, default)).MustHaveHappenedOnceExactly();
        }

    }
}
