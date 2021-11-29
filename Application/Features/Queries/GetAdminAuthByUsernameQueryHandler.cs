using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Queries
{
    public class GetAdminAuthByUsernameQueryHandler : IRequestHandler<GetAdminAuthByUsernameQuery, AdminAuth>
    {
        private readonly IAdminAuthRepository repository;

        public GetAdminAuthByUsernameQueryHandler(IAdminAuthRepository repository)
        {
            this.repository = repository;
        }
        public async Task<AdminAuth> Handle(GetAdminAuthByUsernameQuery request, CancellationToken cancellationToken)
        {
            var admins = await repository.GetAllAsync();
            if (admins == null)
            {
                throw new ArgumentNullException("Admin doesn't exist!");
            }


            return admins.FirstOrDefault(admin => admin.Username == request.Username);
        }

    }
}
