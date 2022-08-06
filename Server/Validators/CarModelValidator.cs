using FluentValidation;
using Server.Models;

namespace Server.Validators
{
    public class CarModelValidator : AbstractValidator<Car>
    {
        public CarModelValidator()
        {
            RuleFor(x => x.Manufacturer).NotEmpty().Length(1);
            RuleFor(x => x.MadeDate).NotEmpty();
        }
    }
}