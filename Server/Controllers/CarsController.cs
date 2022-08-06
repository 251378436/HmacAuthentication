using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Filters;
using Server.Models;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [CustomAuthorizationFilter]
    public class CarsController : ControllerBase
    {
        public CarsController()
        {

        }

        [HttpPost("DefaultBinder")]
        [Authorize]
        public ActionResult<Car> PostCarByDefaultBinder([FromBody]Car car)
        {
            return Ok(car);
        }

        [HttpPost("CustomBinder")]
        [Authorize]
        public ActionResult<CustomBinderCar> PostCarByCustomBinder([FromBody] CustomBinderCar car)
        {
            return Ok(car);
        }
    }
}
