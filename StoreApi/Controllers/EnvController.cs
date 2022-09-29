using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StoreApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnvController : ControllerBase
    {
        private readonly IConfiguration _config;

        public EnvController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_config.GetSection("Message").Value);
        }
    }


}
