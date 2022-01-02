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
    public class GetDataSetQueryHandlerTest
    {
            private readonly GetDataSetQueryHandler handler;
            private readonly IDataSetRepository repository;

            public GetDataSetQueryHandlerTest()
            {
                this.repository = A.Fake<IDataSetRepository>();
                this.handler = new GetDataSetQueryHandler(this.repository);
            }

            [Fact]
            public async void Given_GetDataSetQuery_When_HandleIsCalled_Then_ShouldReturnDataSet()
            {
                // arrange
                List<DataSet> dataSets = new();
                dataSets.Add(new DataSet
                {
                    
                });

                A.CallTo(() => repository.GetAllAsync()).Returns(dataSets);

                // act
                await handler.Handle(new GetDataSetQuery
                {
                
                }, default);

                // assert
                A.CallTo(() => repository.GetAllAsync()).Returns(dataSets);

            } 

            [Fact]
            public void Given_GetDataSetQuery_When_HandleIsCalledAndDataSetIsNull_Then_ShouldThrowException()
            {
                // arrange
                List<DataSet> dataSets = null;

                A.CallTo(() => repository.GetAllAsync()).Returns(dataSets);

                // act
                Func<Task> action = async () => await handler.Handle(new GetDataSetQuery
                {

                }, default);

                // assert
                _ = action.Should().Throw<ArgumentNullException>(); //trebuie ThrowAsync dar nu exista
            }
        }   
}
