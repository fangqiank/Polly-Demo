using Microsoft.AspNetCore.Mvc;

namespace Polly__Demo.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ResponseController : ControllerBase
    {
        [HttpGet]
        [Route("{id}")]
        public ActionResult GetResponse(int id)
        {
            Random rnd = new();
            var rndInteger = rnd.Next(1, 101);
            if(rndInteger >= id)
            {
                Console.WriteLine($"--> Failure({rndInteger.ToString()}) - Generate a Http 500");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            Console.WriteLine($"--> Success({rndInteger.ToString()}) - Generate a Http 200");
            return Ok();
        }
    }
}
