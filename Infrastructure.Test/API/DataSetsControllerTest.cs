using Application.Features.Queries;
using FakeItEasy;
using MediatR;
using WebAPI.Controllers.v1;
using Xunit;

namespace Persistence.Test.API
{
    public class DataSetsControllerTest
    {
        private readonly AdminController controller;
        private readonly IMediator mediator;

        public DataSetsControllerTest()
        {
            this.mediator = A.Fake<IMediator>();
            controller = new AdminController(mediator);
        }

        [Fact]
        public async void Given_DataSetsController_When_GetIsCalled_Then_ShouldReturnADataSetCollection()
        {
            //Arrange and Act

            await controller.GetAllDataSetInfo();
            A.CallTo(() => mediator.Send(A<GetDataSetQuery>._, default)).MustHaveHappenedOnceExactly();
        }

    }
}
