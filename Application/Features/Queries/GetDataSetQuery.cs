using Domain.Entities;
using MediatR;
using System.Collections.Generic;

namespace Application.Features.Queries
{
    public class GetDataSetQuery : IRequest<IEnumerable<DataSet>>
    {
    }
}
