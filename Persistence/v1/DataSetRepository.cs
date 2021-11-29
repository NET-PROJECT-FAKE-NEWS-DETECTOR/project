using Application.Interfaces;
using Domain.Entities;
using Persistence.Context;
using Persistence.v1.Persistence.v1;

namespace Persistence.v1
{
    public class DataSetRepository : Repository<DataSet>, IDataSetRepository
    {
        public DataSetRepository(DataSetContext context) : base(context)
        {
           
        }

    }
}
