using Domain.Entities;
using Persistence.Context;
using Persistence.v1.Persistence.v1;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.v1
{
    public class AdminAuthRepository : Repository<AdminAuth>, IAdminAuthRepository
    {
        public AdminAuthRepository(DataSetContext context) : base(context)
        {
        }
    }
}
