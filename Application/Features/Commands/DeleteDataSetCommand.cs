using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands
{
    public class DeleteDataSetCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
       
    }
}
