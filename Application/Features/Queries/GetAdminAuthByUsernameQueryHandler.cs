using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                throw new Exception("Admin doesn't exist");
            }


            return admins.FirstOrDefault(admin => admin.Username == request.Username);
        }

    }
}
