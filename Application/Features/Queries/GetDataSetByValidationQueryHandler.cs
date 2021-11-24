using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Queries
{
    public class GetDataSetByValidationQueryHandler : IRequestHandler<GetDataSetByValidationQuery, IEnumerable<DataSet>>
    {

        private readonly IDataSetRepository repository;

        public GetDataSetByValidationQueryHandler(IDataSetRepository repository)
        {
            this.repository = repository;
        }
        public async Task<IEnumerable<DataSet>> Handle(GetDataSetByValidationQuery request, CancellationToken cancellationToken)
        {
            var dataSet = await repository.GetAllAsync();
            if (dataSet == null)
            {
                throw new Exception("DataSet doesn't exist");
            }

            dataSet = dataSet.Where(d => d.Validation == request.Validation);

            return dataSet;
        }
    }
}

