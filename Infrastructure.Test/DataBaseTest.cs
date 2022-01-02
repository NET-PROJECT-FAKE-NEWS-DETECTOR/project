using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;

namespace Persistence.Test
{
    public class DataBaseTest : IDisposable
    {

        protected readonly DataSetContext context;

        public DataBaseTest()
        {
            var options = new DbContextOptionsBuilder<DataSetContext>().UseInMemoryDatabase("TestDataBase").Options;

            context = new DataSetContext(options);
            context.Database.EnsureCreated();

            DataBaseInitializer.Initialize(context);
        }
        public void Dispose()
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
