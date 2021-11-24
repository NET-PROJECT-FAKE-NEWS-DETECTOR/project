using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.v1
{
    [ApiController]
    [Route("[controller]")]
    public class HarvestingController : ControllerBase
    {
        [HttpGet]
        public string HarvestEssential()
        {
            return "Reached Harvest Endpoint";
        }

    }
}
