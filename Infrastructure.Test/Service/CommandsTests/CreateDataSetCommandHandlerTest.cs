using Application.Features.Commands;
using Application.Interfaces;
using Domain.Entities;
using FakeItEasy;
using System.Threading.Tasks;
using Xunit;

namespace Persistence.Test.Service
{
    public class CreateDataSetCommandHandlerTest
    {
        private readonly CreateDataSetCommandHandler handler;
        private readonly IDataSetRepository repository;

        public CreateDataSetCommandHandlerTest()
        {
            this.repository = A.Fake<IDataSetRepository>();
            this.handler = new CreateDataSetCommandHandler(this.repository);
        }

        [Fact]
        public async Task Given_CreateDataSetCommandHandler_When_HandleIsCalled_Then_AddAsyncDataSetIsCalled()
        {
            //Arrange and Act
            await handler.Handle(new CreateDataSetCommand(), default);

            //Assert
            A.CallTo(() => repository.AddAsync(A<DataSet>._)).MustHaveHappenedOnceExactly();

        }
    }
}
