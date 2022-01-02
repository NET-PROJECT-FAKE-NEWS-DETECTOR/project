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
            return Ok(await mediator.Send(new GetDataSetByValidationQuery { Validation = validation,
                GroupOrder = 1
            })) ;
        }


        [Route("DataSetInfo")]
        [HttpGet]
        public async Task<IActionResult> GetAllDataSetInfo()
        {
            return Ok(await mediator.Send(new GetDataSetQuery
            { GroupOrder = 1 }));
        }

        [Route("Titles/{groupOrder}")]
        [HttpGet]
        public async Task<IActionResult> GetTitles(int groupOrder)
        {
            return Ok(await mediator.Send(new GetDataSetTitleByOrderQuery { GroupOrder = groupOrder }));
        }

        [Route("TitleInfo/{title}")]
        [HttpGet]
        public async Task<IActionResult> GetTitleInfo(string title)
        {
            return Ok(await mediator.Send(new GetDataSetByTitleQuery { Title = title }));
        }



        [Route("Register")]
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] CreateAdminAuthCommand command)
        {
            return Ok(await mediator.Send(command));
        }

        //[Route("Admins")]
        //[HttpGet]
        //public async Task<IActionResult> GetAdminInfo()
        //{
        //    return Ok(await mediator.Send(new GetAdminAuthQuery()));
        //}


        [Route("AddData")]
        [HttpPost]
        public async Task<IActionResult> AddData([FromBody] CreateDataSetCommand command)
        {
            return Ok(await mediator.Send(command));
        }


        //[Route("UpdateData")]
        //[HttpPut]
        //public async Task<IActionResult> Update(Guid id, [FromBody] UpdateDataSetCommand command)
        //{
        //    if (id != command.Id)
        //    {
        //        return BadRequest();
        //    }

        //    return Ok(await mediator.Send(command));
        //}

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
