using MediatR;
using System;

namespace Application.Features.Commands
{
    public class DeleteDataSetCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
       
    }
}
