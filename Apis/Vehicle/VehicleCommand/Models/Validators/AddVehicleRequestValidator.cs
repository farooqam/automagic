using System;
using FluentValidation;

namespace Automagic.Apis.Vehicle.VehicleCommand.Models.Validators
{
    public class AddVehicleRequestValidator : AbstractValidator<AddVehicleRequest>
    {
        public AddVehicleRequestValidator()
        {
            RuleFor(r => r.Vin).NotEmpty().WithMessage("Specify a vin.").WithErrorCode("10100");
            RuleFor(r => r.Vin).Length(17).WithMessage("A valid VIN is 17 characters in length.").WithErrorCode("10101");

            short minYear = 1981;
            var maxYear = (short)(DateTime.Today.Year + 1);
           
            RuleFor(r => r.Year).InclusiveBetween(minYear, maxYear).WithMessage($"Year must be between {minYear} and {maxYear}").WithErrorCode("10102");
            RuleFor(r => r.Type).NotEqual(VehicleType.NotSpecified).WithMessage("Specify the vehicle type.").WithErrorCode("10103");
            RuleFor(r => r.Make).NotEmpty().WithMessage("Specify a make.").WithErrorCode("10104");
            RuleFor(r => r.Model).NotEmpty().WithMessage("Specify a model.").WithErrorCode("10105");
            RuleFor(r => r.Price).GreaterThan(0).WithMessage("Price must be greater than zero.").WithErrorCode("10106");
            RuleFor(r => r.Odometer).GreaterThanOrEqualTo(0).WithMessage("Odometer cannot be less than zero.").WithErrorCode("10107");
            RuleFor(r => r.OdometerUnit).NotEqual(Unit.NotSpecified).WithMessage("Specify the odometer unit.").WithErrorCode("10108");

        }
    }
}
