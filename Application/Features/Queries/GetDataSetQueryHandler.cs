using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System.Collections.Generic;
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
            return await repository.GetAllAsync();
        }
    }
}
