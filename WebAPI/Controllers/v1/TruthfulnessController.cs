
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Application.Features.DecisionAlgorithm;
using Application.Features.HttpBodyRequest;
using Microsoft.AspNetCore.Http;


namespace WebAPI.Controllers.v1
{

    [ApiVersion("1.0")]
    public class TruthfulnessController : BaseController
    {
        public TruthfulnessController(IMediator mediator) : base(mediator)
        {
        }

        // [Route("TruthfulnessController/{url}")]
        [Route("TruthfulnessController")]
        [ActionName("GetResult")]
        [HttpPost]
        public ActionResult GetResult()
        {
            HarvestingController harvesting = new();
            var url = Request.Form["flink"].ToString();
            var news = harvesting.Harvesting(url);
            var result = NewsPrediction.Predict(news[0], news[1], "news");
            //var result = true;
            return Content("This is " + result.ToString());
        }

    }
}
