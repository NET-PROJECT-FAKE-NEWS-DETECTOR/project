using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Commands
{
    public class CreateAdminAuthCommandHandler : IRequestHandler<CreateAdminAuthCommand, Guid>
    {
        private readonly IAdminAuthRepository repository;

        public CreateAdminAuthCommandHandler(IAdminAuthRepository repository)
        {
            this.repository = repository;
        }
        public async Task<Guid> Handle(CreateAdminAuthCommand request, CancellationToken cancellationToken)
        {
            var adminAuth = new AdminAuth
            {
                Username = request.Username,
                Password = request.Password,
            };

            await repository.AddAsync(adminAuth);
            return adminAuth.Id;
        }

    }
}
