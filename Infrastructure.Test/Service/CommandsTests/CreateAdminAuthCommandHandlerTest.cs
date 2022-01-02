using Application.Features.Commands;
using Application.Interfaces;
using Domain.Entities;
using FakeItEasy;
using System.Threading.Tasks;
using Xunit;


namespace Persistence.Test.Service
{
    public class CreateAdminAuthCommandHandlerTest
    {
        private readonly CreateAdminAuthCommandHandler handler;
        private readonly IAdminAuthRepository repository;

        public CreateAdminAuthCommandHandlerTest()
        {
            this.repository = A.Fake<IAdminAuthRepository>();
            this.handler = new CreateAdminAuthCommandHandler(this.repository);
        }

        [Fact]
        public async Task Given_CreateAdminAuthCommandHandler_When_HandleIsCalled_Then_AddAsyncAdminAuthIsCalled()
        {
            //Arrange and Act
            await handler.Handle(new CreateAdminAuthCommand(), default);

            //Assert
            A.CallTo(() => repository.AddAsync(A<AdminAuth>._)).MustHaveHappenedOnceExactly();

        }
    }
}
