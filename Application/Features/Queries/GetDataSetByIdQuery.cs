using Domain.Entities;
using MediatR;
using System;

namespace Application.Features.Queries
{
    public class GetDataSetByIdQuery : IRequest<DataSet>
    {
        public Guid Id { get; set; }
    }
}
