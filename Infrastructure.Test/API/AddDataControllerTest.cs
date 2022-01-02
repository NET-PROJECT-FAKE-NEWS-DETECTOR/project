using Application.Features.Commands;
using FakeItEasy;
using MediatR;
using WebAPI.Controllers.v1;
using Xunit;

namespace Persistence.Test.API
{
    public class AddDataControllerTest
    {
        private readonly AdminController controller;
        private readonly IMediator mediator;

        public AddDataControllerTest()
        {
            this.mediator = A.Fake<IMediator>();
            controller = new AdminController(mediator);
        }

        [Fact]
        public async void Given_AddDataController_When_PostIsCalled_Then_ShouldReturnADataSet()
        {
            //Arrange and Act

            CreateDataSetCommand dataSet = new()
            {
                Title = "test if create controller works",
                Validation = false
            };

            await controller.AddData(dataSet);
            A.CallTo(() => mediator.Send(A<CreateDataSetCommand>._, default)).MustHaveHappenedOnceExactly();
        }
    }
}
