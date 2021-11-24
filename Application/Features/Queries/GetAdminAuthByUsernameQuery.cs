using Domain.Entities;
using MediatR;

namespace Application.Features.Queries
{
    public class GetAdminAuthByUsernameQuery : IRequest<AdminAuth>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
