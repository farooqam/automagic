using FluentValidation;

namespace Automagic.Apis.Vehicle.VehicleCommand.Models.Validators
{
    public class AddVehicleRequestValidator : AbstractValidator<AddVehicleRequest>
    {
        public AddVehicleRequestValidator()
        {
            RuleFor(r => r.Vin).NotEmpty().WithMessage("Specify a vin.").WithErrorCode("10100");
            RuleFor(r => r.Vin).Length(17).WithMessage("A valid VIN is 17 characters in length.").WithErrorCode("10300");
        }
    }
}
