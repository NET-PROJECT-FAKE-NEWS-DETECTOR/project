using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IApplicationContext
    {
        DbSet<Domain.Entities.DataSet> DataSet { get; set; }

        DbSet<Domain.Entities.AdminAuth> AdminAuth { get; set; }
        Task<int> SaveChangesAsync();
    }
}
