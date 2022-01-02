using Domain.Entities;
using MediatR;
using System.Collections.Generic;

namespace Application.Features.Queries
{
    public class GetDataSetByValidationQuery : IRequest<IEnumerable<DataSet>>
    {
        public bool Validation { get; set; }

        public int GroupOrder { get; set; }
    }
}
