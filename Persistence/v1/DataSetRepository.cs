using Application.Interfaces;
using Domain.Entities;
using Persistence.Context;
using Persistence.v1.Persistence.v1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.v1
{
    public class DataSetRepository : Repository<DataSet>, IDataSetRepository
    {
        public DataSetRepository(DataSetContext context) : base(context)
        {
           
        }

    }
}
