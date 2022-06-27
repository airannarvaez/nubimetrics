using Microsoft.AspNetCore.Mvc;

namespace Nubimetrics.WebApi.Controllers
{
    [Route("busqueda")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly ILogger<CountriesController> _logger;
        private readonly ApiClientFactory _apiClient;

        public SearchController(ILogger<CountriesController> logger, ApiClientFactory apiClient)
        {
            _logger = logger;
            _apiClient = apiClient;
        }

        [HttpGet("{text}")]
        public async Task<IActionResult> Get(string text)
        {
            var api = _apiClient.Instance();
            return Ok(await api.SearchText(text));
        }
    }
}
