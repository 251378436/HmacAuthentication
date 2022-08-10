using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Server.Models.Client;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutomapperController : ControllerBase
    {
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

            return Ok(mapperResponse);
        }
    }
}