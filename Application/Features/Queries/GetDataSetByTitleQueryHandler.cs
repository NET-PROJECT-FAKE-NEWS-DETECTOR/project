using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace Application.Features.Queries
{
    public class GetDataSetByTitleQueryHandler : IRequestHandler<GetDataSetByTitleQuery, IEnumerable<DataSet>>
    {
        private readonly IDataSetRepository repository;

        public GetDataSetByTitleQueryHandler(IDataSetRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<DataSet>> Handle(GetDataSetByTitleQuery request, CancellationToken cancellationToken)
        {
            var dataSet = await repository.GetAllAsync();
            return dataSet.Where(d => d.Title == request.Title);
        }
    }
}
