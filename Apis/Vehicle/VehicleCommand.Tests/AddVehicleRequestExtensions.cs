using Automagic.Apis.Vehicle.VehicleCommand.Models;

namespace Automagic.Apis.Vehicle.VehicleCommand.Tests
{
    public static class AddVehicleRequestExtensions
    {
        public static AddVehicleRequest RemoveVin(this AddVehicleRequest request)
        {
            request.Vin = null;
            return request;
        }

        public static AddVehicleRequest UpdateVin(this AddVehicleRequest request, string vin)
        {
            request.Vin = vin;
            return request;
        }

        public static AddVehicleRequest UpdateYear(this AddVehicleRequest request, short year)
        {
            request.Year = year;
            return request;
        }

        public static AddVehicleRequest UpdateType(this AddVehicleRequest request, VehicleType type)
        {
            request.Type = type;
            return request;
        }

        public static AddVehicleRequest UpdateMake(this AddVehicleRequest request, string make)
        {
            request.Make = make;
            return request;
        }

        public static AddVehicleRequest UpdateModel(this AddVehicleRequest request, string model)
        {
            request.Model = model;
            return request;
        }

        public static AddVehicleRequest UpdateTrim(this AddVehicleRequest request, string trim)
        {
            request.Trim = trim;
            return request;
        }

        public static AddVehicleRequest UpdatePrice(this AddVehicleRequest request, decimal price)
        {
            request.Price = price;
            return request;
        }

        public static AddVehicleRequest UpdateOdometer(this AddVehicleRequest request, decimal odometer)
        {
            request.Odometer = odometer;
            return request;
        }

        public static AddVehicleRequest UpdateOdometerUnit(this AddVehicleRequest request, Unit unit)
        {
            request.OdometerUnit = unit;
            return request;
        }
    }
}
