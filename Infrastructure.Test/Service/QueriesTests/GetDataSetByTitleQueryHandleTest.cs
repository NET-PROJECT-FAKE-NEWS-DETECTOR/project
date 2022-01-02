using Application.Features.Queries;
using Application.Interfaces;
using Domain.Entities;
using FakeItEasy;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Persistence.Test.Service.QueriesTests
{
    public class GetDataSetByTitleQueryHandleTest
    {
        private readonly GetDataSetByTitleQueryHandler handler;
        private readonly IDataSetRepository repository;

        public GetDataSetByTitleQueryHandleTest()
        {
            this.repository = A.Fake<IDataSetRepository>();
            this.handler = new GetDataSetByTitleQueryHandler(this.repository);
        }

        [Fact]
        public async void Given_GetDataSetByTitleQuery_When_HandleIsCalled_Then_ShouldReturnDataSet()
        {
            // arrange
            List<DataSet> dataSets = new();
            dataSets.Add(new DataSet
            {
                Title = "Test if get by title works"
            });

            A.CallTo(() => repository.GetAllAsync()).Returns(dataSets);

            // act
            await handler.Handle(new GetDataSetByTitleQuery
            {
                Title = "Test if get by title works"
            }, default);

            // assert
            A.CallTo(() => repository.GetAllAsync()).MustHaveHappenedOnceExactly();

        }

        [Fact]
        public void Given_GetDataSetByTitleQuery_When_HandleIsCalledAndDataSetIsNull_Then_ShouldThrowException()
        {
            // arrange
            List<DataSet> dataSets = null;

            A.CallTo(() => repository.GetAllAsync()).Returns(dataSets);

            // act
            Func<Task> action = async () => await handler.Handle(new GetDataSetByTitleQuery
            {
                Title = "Test if get by title works"

            }, default);

            // assert
            _ = action.Should().Throw<ArgumentNullException>(); //trebuie ThrowAsync dar nu exista
        }
    }
}
