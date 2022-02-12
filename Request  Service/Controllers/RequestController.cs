using Microsoft.AspNetCore.Mvc;
using Request__Service.Policies;

namespace Request__Service.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class RequestController : ControllerBase
    {
        //private readonly IClientPolicy _clientPolicy;
        private readonly IHttpClientFactory _clientFactory;

        public RequestController(
            /*IClientPolicy clientPolicy,*/
            IHttpClientFactory clientFactory
            )
        {
            //_clientPolicy = clientPolicy;
            _clientFactory = clientFactory;
        }

        [HttpGet]
        public async Task<ActionResult> MakeRequest()
        {
            //var client = new HttpClient();
            var client = _clientFactory.CreateClient("Test");

            var response = await client.GetAsync("https://localhost:5001/api/response/60");

            //var response = await _clientPolicy.ImmediateHttpRetry.ExecuteAsync(
            //    () => client.GetAsync("https://localhost:5001/api/response/60")
            //   );

            //var response = await _clientPolicy.LinearHttpRetry.ExecuteAsync(
            //    () => client.GetAsync("https://localhost:5001/api/response/60")
            //   );

            //var response = await _clientPolicy.ExponentialHttpRetry.ExecuteAsync(
            //    () => client.GetAsync("https://localhost:5001/api/response/60")
            //    );

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("--> Response service returned success");
                return Ok();
            }

            Console.WriteLine("--> Response service returned failure");
            return StatusCode(StatusCodes.Status500InternalServerError);
        } 
    }
}
