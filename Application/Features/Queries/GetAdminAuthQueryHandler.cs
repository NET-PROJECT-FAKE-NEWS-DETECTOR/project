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
    public class GetAdminAuthQueryHandler : IRequestHandler<GetAdminAuthQuery, IEnumerable<AdminAuth>>
    {
        private readonly IAdminAuthRepository repository;

        public GetAdminAuthQueryHandler(IAdminAuthRepository repository)
        {
            this.repository = repository;
        }
        public async Task<IEnumerable<AdminAuth>> Handle(GetAdminAuthQuery request, CancellationToken cancellationToken)
        {
            return await repository.GetAllAsync();
        }
    }
}
