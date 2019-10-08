using Microsoft.AspNetCore.Mvc;

namespace WebAPIStarter.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GreetingController : ControllerBase
    {
        [HttpGet]
        public string Get() {
            return "Hello from Oregon!";
        } 
    }
}