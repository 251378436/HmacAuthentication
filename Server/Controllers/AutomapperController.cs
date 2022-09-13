using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Server.Models;
using Server.Models.Client;
using Prometheus;

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
        public AutomapperController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult<MapperResponse> GetResult([FromBody] MapperRequest mapperRequest)
        {
            var mapperResponse = _mapper.Map<MapperResponse>(mapperRequest);

            ControlPayCountByOutcome.WithLabels("outcome").Inc();
            return Ok(mapperResponse);
        }

        [HttpPost("CreateCar")]
        public ActionResult<Car> CreateCar([FromHeader(Name = "x-name")]string name, [FromBody] Car car)
        {
            return Ok(car);
        }
    }
}