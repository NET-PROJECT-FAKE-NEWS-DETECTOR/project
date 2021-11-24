using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.v1
{

    [ApiController]
    [Route("[controller]")]
    public class TruthfulnessController : ControllerBase
    {
        [HttpGet]
        public string GetResult()
        {
            return "Send the result";
        }

    }
}
