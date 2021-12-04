using Application.Features.Commands;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using MediatR;
using Application.Features.Queries;

namespace WebAPI.Controllers.v1
{
    [ApiVersion("1.0")]
    public class AdminController : BaseController
    {

        public AdminController(IMediator mediator) : base(mediator)
        {
        }

        [Route("TrueInfo")]
        [HttpGet]
        public async Task<IActionResult> GetTrueInfo(bool validation)
        {
            return Ok(await mediator.Send(new GetDataSetByValidationQuery { Validation = validation}));
        }

        [Route("FakeInfo")]
        [HttpGet]
        public async Task<IActionResult> GetFakeInfo()
        {
            return Ok(await mediator.Send(new GetDataSetByValidationQuery()));
        }

        [Route("DataSetInfo")]
        [HttpGet]
        public async Task<IActionResult> GetAllDataSetInfo()
        {
            return Ok(await mediator.Send(new GetDataSetQuery()));
        }


        [Route("Register")]
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] CreateAdminAuthCommand command)
        {
            return Ok(await mediator.Send(command));
        }

        [Route("Admins")]
        [HttpGet]
        public async Task<IActionResult> GetAdminInfo()
        {
            return Ok(await mediator.Send(new GetAdminAuthQuery()));
        }


        [Route("AddData")]
        [HttpPost]
        public async Task<IActionResult> AddData([FromBody] CreateDataSetCommand command)
        {
            return Ok(await mediator.Send(command));
        }


        [Route("UpdateData")]
        [HttpPut]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateDataSetCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            return Ok(await mediator.Send(command));
        }

        [HttpDelete]
        [Route("DeleteData")]
        public async Task<IActionResult> DeleteData(Guid id, [FromBody] DeleteDataSetCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            return Ok(await mediator.Send(command));
        }

    }
}
