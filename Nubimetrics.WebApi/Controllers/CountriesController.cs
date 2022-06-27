using Microsoft.AspNetCore.Mvc;

namespace Nubimetrics.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CountriesController : ControllerBase
    {
        private readonly ILogger<CountriesController> _logger;

        public CountriesController(ILogger<CountriesController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public Country Get()
        {
            return new Country();
        }
    }
}