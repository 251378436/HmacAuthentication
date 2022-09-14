using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Server.Models;
using Server.Models.Client;
using Prometheus;
using Server.Cache;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutomapperController : ControllerBase
    {
        private static readonly Counter ControlPayCountByOutcome = Metrics
        .CreateCounter("control_pay_count_by_outcome", "Number of control pay responses by outcome",
            new CounterConfiguration { LabelNames = new[] { "outcome" } });

        private readonly IMapper _mapper;
        private ITokenCache _tokenCache;
        public AutomapperController(IMapper mapper, ITokenCache tokenCache)
        {
            _mapper = mapper;
            _tokenCache = tokenCache;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> GetResult([FromBody] MapperRequest mapperRequest, CancellationToken cancellationToken)
        {
            var mapperResponse = _mapper.Map<MapperResponse>(mapperRequest);

            ControlPayCountByOutcome.WithLabels("outcome").Inc();

            var result = await _tokenCache.FetchToken(cancellationToken);
            //return Ok(mapperResponse);
            return Ok(result);
        }

        [HttpPost("CreateCar")]
        public ActionResult<Car> CreateCar([FromHeader(Name = "x-name")]string name, [FromBody] Car car)
        {
            return Ok(car);
        }
    }
}