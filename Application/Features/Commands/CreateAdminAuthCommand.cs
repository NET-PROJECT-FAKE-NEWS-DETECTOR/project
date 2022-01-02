using MediatR;
using System;

namespace Application.Features.Commands
{
    public class CreateAdminAuthCommand : IRequest<Guid>
    {
        public string Username { get; set; }

        public string Password { get; set; }

    }
}
