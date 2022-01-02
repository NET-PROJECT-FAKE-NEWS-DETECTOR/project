using Application.Features.Commands;
using Application.Interfaces;
using Domain.Entities;
using FakeItEasy;
using FluentAssertions;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Persistence.Test.Service
{
    public class DeleteDataSetCommandHandlerTest
    {
        private readonly DeleteDataSetCommandHandler handler;
        private readonly IDataSetRepository repository;

        public DeleteDataSetCommandHandlerTest()
        {
            this.repository = A.Fake<IDataSetRepository>();
            this.handler = new DeleteDataSetCommandHandler(this.repository);
        }

        [Fact]
        public async void Given_DeleteDataSetCommand_When_HandleIsCalled_Then_ShouldReturnDeleteDataSet()
        {
            // arrange
            DataSet dataSet = new DataSet
            {
                Id = new Guid("4947864a-1cc0-4a2f-a8a4-4400b4bf2166")
            };

            A.CallTo(() => repository.GetByIdAsync(new Guid("4947864a-1cc0-4a2f-a8a4-4400b4bf2166"))).Returns(dataSet);

            // act
            await handler.Handle(new DeleteDataSetCommand
            {
                Id = new Guid("4947864a-1cc0-4a2f-a8a4-4400b4bf2166")
            }, default);

            // assert
            A.CallTo(() => repository.DeleteAsync(A<DataSet>._)).MustHaveHappenedOnceExactly();
        }

        [Fact]
        public void Given_DeleteDataSetCommand_When_HandleIsCalledAndDataSetIsNull_Then_ShouldThrowException()
        {
            // arrange
            DataSet dataSet = null;

            A.CallTo(() => repository.GetByIdAsync(new Guid("4947864a-1cc0-4a2f-a8a4-4400b4bf2166"))).Returns(dataSet);

            // act
            Func<Task> action = async () => await handler.Handle(new DeleteDataSetCommand
            {
                Id = new Guid("4947864a-1cc0-4a2f-a8a4-4400b4bf2166")
            }, default);

            // assert
            _ = action.Should().Throw<ArgumentNullException>(); //trebuie ThrowAsync dar nu exista
        }
    }
}
