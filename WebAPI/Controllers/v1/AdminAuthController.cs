using Application.Features.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers.v1
{
    [ApiVersion("1.0")]
    public class AdminAuthController : BaseController
    {
        public AdminAuthController(IMediator mediator) : base(mediator)
        {
        }


        [Route("LogIn")]
        [HttpGet]
        public async Task<IActionResult> GetAdminInfo(string username)
        {
            return Ok(await mediator.Send(new GetAdminAuthByUsernameQuery { Username = username }));
        }



    }
}
