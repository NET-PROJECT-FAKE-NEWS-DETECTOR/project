using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Persistence.Context
{
    public class DataSetContext : DbContext
    {

        public DataSetContext(DbContextOptions<DataSetContext> options) : base(options)
        {
        }

        public DbSet<DataSet> DataSets { get; set; }

        public DbSet<AdminAuth> AdminAuth { get; set; }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }


        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseMySQL("server=localhost;database=dotnetproject;user=root;password=juventus10");
        //}


    }
}
