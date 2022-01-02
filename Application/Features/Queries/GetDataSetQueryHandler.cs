using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Queries
{
    public class GetDataSetQueryHandler : IRequestHandler<GetDataSetQuery, IEnumerable<DataSet>>
    {
        private readonly IDataSetRepository repository;

        public GetDataSetQueryHandler(IDataSetRepository repository)
        {
            this.repository = repository;
        }
        public async Task<IEnumerable<DataSet>> Handle(GetDataSetQuery request, CancellationToken cancellationToken)
        {
            var dataSet = await repository.GetAllAsync();
            if (dataSet == null)
            {
                throw new ArgumentNullException("Data doesn't exist!");
            }

            if (dataSet.Count() > 10)
                dataSet = dataSet.Skip(10 * (request.GroupOrder - 1));

            if (dataSet.Count() > 10)
                dataSet = dataSet.SkipLast(dataSet.Count() - 10 * request.GroupOrder);

            

            return dataSet;
        }
    }
}
