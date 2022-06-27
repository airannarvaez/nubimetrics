using Microsoft.AspNetCore.Mvc;
using Nubimetrics.Common.Enums;

namespace Nubimetrics.WebApi.Controllers
{
    [ApiController]
    [Route("paises")]
    public class CountriesController : ControllerBase
    {
        private readonly ILogger<CountriesController> _logger;
        private readonly ApiClientFactory _apiClient;

        public CountriesController(ILogger<CountriesController> logger, ApiClientFactory apiClient)
        {
            _logger = logger;
            _apiClient = apiClient;
        }

        [HttpGet("{countryCode}")]
        public async Task<IActionResult> Get(string countryCode)
        {
            if (Enum.TryParse(countryCode, out CountryCode code))
            {
                if (code == CountryCode.AR)
                {
                    var api = _apiClient.Instance();
                    return Ok(await api.GetCountry(countryCode));
                }
                else
                {
                    return Unauthorized();
                }
            }
            return BadRequest();

        }
    }
}