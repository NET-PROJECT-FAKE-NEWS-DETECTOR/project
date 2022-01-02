using Domain.Entities;
using FluentAssertions;
using Persistence.v1.Persistence.v1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Persistence.Test.Data
{
    public class AdminAuthRepositoryTest : DataBaseTest
    {
        private readonly Repository<AdminAuth> repository;
        private readonly AdminAuth newAdminAuth;

        public AdminAuthRepositoryTest()
        {
            repository = new Repository<AdminAuth>(context);
            newAdminAuth = new AdminAuth()
            {
                Id = Guid.Parse("46998817-f5cf-492a-b3e3-7e9213a47e54"),
                Username = "adminTest2",
                Password = "adminTestPass2"
            };
        }

        [Fact]
        public async void Given_NewAdmin_When_AdminIsNotNull_Then_AddAsyncShouldReturnANewAdmin()
        {
            //Arrange and act
            var result = await repository.AddAsync(newAdminAuth);

            //Assert
            result.Should().BeOfType<AdminAuth>();
        }
    }
}
