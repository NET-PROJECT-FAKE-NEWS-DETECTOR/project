using Domain.Entities;
using FluentAssertions;
using Persistence.v1.Persistence.v1;
using System;
using Xunit;

namespace Persistence.Test.Data
{
    public class DataSetRepositoryTest : DataBaseTest
    {
        private readonly Repository<DataSet> repository;
        private readonly DataSet newDataSet;

        public DataSetRepositoryTest()
        {
            repository = new Repository<DataSet>(context);
            newDataSet = new DataSet()
            {
                Id = Guid.Parse("f1cb0bad-3bcd-4a4e-b53e-109d14c12211"),
                Title = "Test DataSet Repo",
                Text = "nothing",
                Subject = "Politic",
                Validation = true
            };
        }

        [Fact]
        public async void Given_NewDataSet_When_DataSetIsNotNull_Then_AddAsyncShouldReturnANewDataSet()
        {
            //Arrange and act
            var result = await repository.AddAsync(newDataSet);

            //Assert
            result.Should().BeOfType<DataSet>();
        }
    }
}
