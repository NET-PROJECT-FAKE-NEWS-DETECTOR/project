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
    public class GetDataSetByIdQueryHandler : IRequestHandler<GetDataSetByIdQuery, DataSet>
    {
        private readonly IDataSetRepository repository;

        public GetDataSetByIdQueryHandler(IDataSetRepository repository)
        {
            this.repository = repository;
        }
        public async Task<DataSet> Handle(GetDataSetByIdQuery request, CancellationToken cancellationToken)
        {
            var dataSet = await repository.GetByIdAsync(request.Id);
            if (dataSet == null)
            {
                throw new Exception("Data doesn't exist");
            }

            return dataSet;
        }
    }
}
