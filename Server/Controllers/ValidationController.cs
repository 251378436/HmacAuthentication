using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Server.Filters;
using Server.Models;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValidationController : ControllerBase
    {
        private IValidator<Car> _validator;
        public ValidationController(IValidator<Car> validator)
        {
            _validator = validator;
        }

        [HttpPost]
        [Custom1ActionFilter]
        public async Task<ActionResult<Car>> PostAsync([FromBody] Car car)
        {
            await _validator.ValidateAndThrowAsync(car);

            return Ok(car);
        }
    }
}