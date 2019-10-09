using Microsoft.AspNetCore.Mvc;

namespace WebAPIStarter.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GreetingController : ControllerBase
    {
        [HttpGet("{username}/{reponame}")]
        public string Get(string username, string reponame) {

            return "Hello from Oregon!";
        } 
    }
}