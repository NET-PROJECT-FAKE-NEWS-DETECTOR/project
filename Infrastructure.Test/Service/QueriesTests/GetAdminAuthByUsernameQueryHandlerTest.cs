using Application.Features.Queries;
using Application.Interfaces;
using Domain.Entities;
using FakeItEasy;
using System.Threading.Tasks;
using System;
using Xunit;
using System.Collections.Generic;
using FluentAssertions;

namespace Persistence.Test.Service.QueriesTests
{
    public class GetAdminAuthByUsernameQueryHandlerTest
    {
        private readonly GetAdminAuthByUsernameQueryHandler handler;
        private readonly IAdminAuthRepository repository;

        public GetAdminAuthByUsernameQueryHandlerTest()
        {
            this.repository = A.Fake<IAdminAuthRepository>();
            this.handler = new GetAdminAuthByUsernameQueryHandler(this.repository);
        }

        [Fact]
        public async void Given_GetAdminAuthByUsernameQuery_When_HandleIsCalled_Then_ShouldReturnAdminAuth()
        {
            // arrange
            List<AdminAuth> adminAuth = new();
            adminAuth.Add(new AdminAuth
            {
                Username = "adminTestUsername"
            });

            A.CallTo(() => repository.GetAllAsync()).Returns(adminAuth);

            // act
            await handler.Handle(new GetAdminAuthByUsernameQuery
            {
                Username = "adminTestUsername"
                //Password = "adminTestPassword"
            }, default);

            // assert
            A.CallTo(() => repository.GetAllAsync()).MustHaveHappenedOnceExactly();

        }

        [Fact]
        public void Given_GetAdminAuthByUsernameQuery_When_HandleIsCalledAndAdminAuthIsNull_Then_ShouldThrowException()
        {
            // arrange
            List<AdminAuth> adminAuth = null;

            A.CallTo(() => repository.GetAllAsync()).Returns(adminAuth);

            // act
            Func<Task> action = async () => await handler.Handle(new GetAdminAuthByUsernameQuery
            {
                Username = "adminTestUsername"
                //Password = "adminTestPassword"

            }, default);

            // assert
            _ = action.Should().Throw<ArgumentNullException>(); //trebuie ThrowAsync dar nu exista
        }
    }
}
