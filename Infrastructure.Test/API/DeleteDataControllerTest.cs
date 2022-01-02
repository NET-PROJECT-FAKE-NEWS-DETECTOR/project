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
    public class DeleteDataControllerTest
    {
        private readonly AdminController controller;
        private readonly IMediator mediator;

        public DeleteDataControllerTest()
        {
            this.mediator = A.Fake<IMediator>();
            controller = new AdminController(mediator);
        }

        [Fact]
        public async void Given_DeleteDataController_When_DeleteIsCalled_Then_ShouldReturnADataSet()
        {
            //Arrange and Act

            Guid id = Guid.Parse("1f8cb18b-f8a0-4328-9b40-898ff1159e32");

            DeleteDataSetCommand dataSet = new()
            {
               Id = Guid.Parse("1f8cb18b-f8a0-4328-9b40-898ff1159e32")
            };

            await controller.DeleteData(id, dataSet);
            A.CallTo(() => mediator.Send(A<DeleteDataSetCommand>._, default)).MustHaveHappenedOnceExactly();
        }
    }
}
