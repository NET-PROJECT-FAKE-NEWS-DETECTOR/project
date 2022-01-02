using Domain.Entities;
using Persistence.Context;
using System;
using System.Linq;
using Xunit;

namespace Persistence.Test
{
    public class DataBaseInitializer
    {
        public static void Initialize(DataSetContext context)
        {
            if(context.DataSets.Any())
            {
                return;
            }
            //Seed(context);

        }

        private static void Seed(DataSetContext context)
        {
            DateTime date1 = new DateTime(2015, 12, 31);
            DateTime date2 = new DateTime(2016, 12, 31);
            var dataSets = new[]
            {

                new DataSet
                {
                    Id = Guid.Parse("1f8cb18b-f8a0-4328-9b40-898ff1159e32"),
                    Title = "FakeNews",
                    Text = "TestDataSet",
                    Date = date1,
                    Validation = false
                },

                 new DataSet
                {
                    Id = Guid.Parse("425c5990-574d-445e-9e5b-1af4b30b3eb5"),
                    Title = "TrueNews",
                    Text = "TestDataSet",
                    Date = date2,
                    Validation = true
                }
            };

            context.DataSets.AddRange(dataSets);
            context.SaveChanges();
        }
    }
}
