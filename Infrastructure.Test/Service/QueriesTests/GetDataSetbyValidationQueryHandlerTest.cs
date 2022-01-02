using Application.Features.Queries;
using Application.Interfaces;
using Domain.Entities;
using FakeItEasy;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Persistence.Test.Service.QueriesTests
{
    public class GetDataSetbyValidationQueryHandlerTest
    {
        private readonly GetDataSetByValidationQueryHandler handler;
        private readonly IDataSetRepository repository;

        public GetDataSetbyValidationQueryHandlerTest()
        {
            this.repository = A.Fake<IDataSetRepository>();
            this.handler = new GetDataSetByValidationQueryHandler(this.repository);
        }

        [Fact]
        public async void Given_GetDataSetByValidationQuery_When_HandleIsCalled_Then_ShouldReturnDataSet() 
        {
            // arrange
            List<DataSet> dataSets = new();
            dataSets.Add(new DataSet
            {
                Validation = true
            });

            A.CallTo(() => repository.GetAllAsync()).Returns(dataSets);

            // act
            await handler.Handle(new GetDataSetByValidationQuery
            {
                Validation = true
            }, default);

            // assert
            A.CallTo(() => repository.GetAllAsync()).Returns(dataSets);

        }

        [Fact]
        public void Given_GetDataSetByValidationQuery_When_HandleIsCalledAndDataSetIsNull_Then_ShouldThrowException()
        {
            // arrange
            List<DataSet> dataSets = null;

            A.CallTo(() => repository.GetAllAsync()).Returns(dataSets);

            // act
            Func<Task> action = async () => await handler.Handle(new GetDataSetByValidationQuery
            {
                Validation = true

            }, default);

            // assert
            _ = action.Should().Throw<ArgumentNullException>(); //trebuie ThrowAsync dar nu exista
        }
    }
}
