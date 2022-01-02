using Domain.Entities;
using MediatR;
using System.Collections.Generic;

namespace Application.Features.Queries
{
    public class GetDataSetByTitleQuery : IRequest<IEnumerable<DataSet>>
    {
        public string Title { get; set; }
    }
}
