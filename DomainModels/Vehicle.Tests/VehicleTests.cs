using System;
using Automagic.DomainModels.Core;
using FluentAssertions;
using Xunit;

namespace Automagic.DomainModels.Vehicle.Tests
{
    public sealed class VehicleTests
    {
        [Fact]
        public void GetTheVehicleId()
        {
            // Arrange
            var vehicle = CreateDefaultVehicle();

            // Act
            var id = vehicle.Id;

            // Assert
            id.Should().Be(new VehicleId("id"));
        }

        [Fact]
        public void GetTheVin()
        {
            // Arrange
            var vehicle = CreateDefaultVehicle();

            // Act
            var vin = vehicle.Vin;

            // Assert
            vin.Should().Be(new Vin("vin"));
        }

        [Fact]
        public void GetTheYear()
        {
            // Arrange
            var vehicle = CreateDefaultVehicle();

            // Act
            var year = vehicle.Year;

            // Assert
            year.Should().Be(new Year(2018));
        }

        [Fact]
        public void GetTheMake()
        {
            // Arrange
            var vehicle = CreateDefaultVehicle();

            // Act
            var make = vehicle.Make;

            // Assert
            make.Should().Be(new Make("make"));
        }

        [Fact]
        public void GetTheModel()
        {
            // Arrange
            var vehicle = CreateDefaultVehicle();

            // Act
            var model = vehicle.Model;

            // Assert
            model.Should().Be(new Model("model"));
        }

        [Fact]
        public void GetTheTrim()
        {
            // Arrange
            var vehicle = CreateDefaultVehicle();

            // Act
            var trim = vehicle.Trim;

            // Assert
            trim.Should().Be(new Trim("trim"));
        }

        [Fact]
        public void GetTheExterior()
        {
            // Arrange
            var vehicle = CreateDefaultVehicle();

            // Act
            var exterior = vehicle.Exterior;

            // Assert
            exterior.Should().Be(new Exterior());
        }

        [Fact]
        public void GetTheInterior()
        {
            // Arrange
            var vehicle = CreateDefaultVehicle();

            // Act
            var interior = vehicle.Interior;

            // Assert
            interior.Should().Be(new Interior());
        }

        [Fact]
        public void GetThePrice()
        {
            // Arrange
            var vehicle = CreateDefaultVehicle();

            // Act
            var price = vehicle.Price;

            // Assert
            price.Should().Be(new Price(10000m, Currencies.UnitedStatesDollar));
        }

        [Fact]
        public void GetTheOdometer()
        {
            // Arrange
            var vehicle = CreateDefaultVehicle();

            // Act
            var odometer = vehicle.Odometer;

            // Assert
            odometer.Should().Be(new Odometer(new MilesMeasurement(1000.5m, Units.Miles)));
        }

        [Fact]
        public void WhenVehicleIdNotSpecified_ThrowException()
        {
            // Arrange
            // ReSharper disable once ObjectCreationAsStatement
            Action action = () => Create(
                null, 
                new Vin("vin"),
                new Year(2018), 
                new Make("make"), 
                new Model("model"),
                new Trim("trim"),
                new Exterior(),
                new Interior(),
                new Price(10000m, Currencies.UnitedStatesDollar),
                new Odometer(new MilesMeasurement(1000.5m, Units.Miles)));

            // Act & Assert
            var exception = action.Should()
                .Throw<DomainModelException>()
                .WithMessage("Specify a vehicle id.")
                .Which;

            exception.Root.Should().Be<Vehicle>();
            exception.Child.Should().Be<VehicleId>();

        }

        [Fact]
        public void Vehicles_AreEqual()
        {
            // Arrange
            var v1 = CreateDefaultVehicle();
            var v2 = CreateDefaultVehicle();

            // Act
            var areEqual = v1 == v2;

            // Assert
            areEqual.Should().BeTrue();
        }

        [Fact]
        public void Vehicles_WhenEqual_HaveSameHashCode()
        {
            // Arrange
            var v1 = CreateDefaultVehicle();
            var v2 = CreateDefaultVehicle();

            // Act
            var hashCodesEqual = v1.GetHashCode() == v2.GetHashCode();

            // Assert
            hashCodesEqual.Should().BeTrue();
        }

        [Fact]
        public void Vehicles_AreNotEqual()
        {
            // Arrange
            var v1 = Create(
                new VehicleId("foo"), 
                new Vin("vin"), 
                new Year(2018), 
                new Make("make"), 
                new Model("model"), 
                new Trim("trim"),
                new Exterior(),
                new Interior(),
                new Price(10000m, Currencies.UnitedStatesDollar),
                new Odometer(new MilesMeasurement(1000.5m, Units.Miles)));

            var v2 = Create(
                new VehicleId("bar"),
                new Vin("vin"), 
                new Year(2018), 
                new Make("make"), 
                new Model("model"),
                new Trim("trim"),
                new Exterior(),
                new Interior(),
                new Price(10000m, Currencies.UnitedStatesDollar),
                new Odometer(new MilesMeasurement(1000.5m, Units.Miles)));

            // Act
            var areEqual = v1 == v2;

            // Assert
            areEqual.Should().BeFalse();
        }

        [Fact]
        public void Vehicles_WhenNotEqual_HashCodesNotEqual()
        {
            // Arrange
            var v1 = Create(
                new VehicleId("foo"),
                new Vin("vin"),
                new Year(2018),
                new Make("make"),
                new Model("model"),
                new Trim("trim"),
                new Exterior(),
                new Interior(),
                new Price(10000m, Currencies.UnitedStatesDollar),
                new Odometer(new MilesMeasurement(1000.5m, Units.Miles)));

            var v2 = Create(
                new VehicleId("bar"),
                new Vin("vin"),
                new Year(2018),
                new Make("make"),
                new Model("model"),
                new Trim("trim"),
                new Exterior(),
                new Interior(),
                new Price(10000m, Currencies.UnitedStatesDollar),
                new Odometer(new MilesMeasurement(1000.5m, Units.Miles)));

            // Act
            var hashCodesEqual = v1.GetHashCode() == v2.GetHashCode();

            // Assert
            hashCodesEqual.Should().BeFalse();
        }

        [Fact]
        public void WhenVinNotSpecified_ThrowException()
        {
            // Arrange
            Action action = () => Create(
                new VehicleId("id"), 
                null, 
                new Year(2018), 
                new Make("make"), 
                new Model("model"), 
                new Trim("trim"),
                new Exterior(),
                new Interior(),
                new Price(10000m, Currencies.UnitedStatesDollar),
                new Odometer(new MilesMeasurement(1000.5m, Units.Miles)));

            // Act & Assert
            var exception = action.Should().Throw<DomainModelException>()
                .WithMessage("Specify a vin.")
                .Which;

            exception.Root.Should().Be<Vehicle>();
            exception.Child.Should().Be<Vin>();
        }

        [Fact]
        public void WhenYearNotSpecified_ThrowException()
        {
            // Arrange
            Action action = () => Create(
                new VehicleId("id"), 
                new Vin("vin"), 
                null, 
                new Make("make"), 
                new Model("model"), 
                new Trim("trim"),
                new Exterior(),
                new Interior(),
                new Price(10000m, Currencies.UnitedStatesDollar),
                new Odometer(new MilesMeasurement(1000.5m, Units.Miles)));

            // Act & Assert
            var exception = action.Should().Throw<DomainModelException>()
                .WithMessage("Specify a year.")
                .Which;

            exception.Root.Should().Be<Vehicle>();
            exception.Child.Should().Be<Year>();
        }

        [Fact]
        public void WhenMakeNotSpecified_ThrowException()
        {
            // Arrange
            Action action = () => Create(
                new VehicleId("id"),
                new Vin("vin"), 
                new Year(2018), 
                null, 
                new Model("model"), 
                new Trim("trim"),
                new Exterior(),
                new Interior(),
                new Price(10000m, Currencies.UnitedStatesDollar),
                new Odometer(new MilesMeasurement(1000.5m, Units.Miles)));

            // Act & Assert
            var exception = action.Should().Throw<DomainModelException>()
                .WithMessage("Specify a make.")
                .Which;

            exception.Root.Should().Be<Vehicle>();
            exception.Child.Should().Be<Make>();
        }

        [Fact]
        public void WhenModelNotSpecified_ThrowException()
        {
            // Arrange
            Action action = () => Create(
                new VehicleId("id"), 
                new Vin("vin"), 
                new Year(2018), 
                new Make("make"), 
                null, 
                new Trim("trim"),
                new Exterior(),
                new Interior(),
                new Price(10000m, Currencies.UnitedStatesDollar),
                new Odometer(new MilesMeasurement(1000.5m, Units.Miles)));

            // Act & Assert
            var exception = action.Should().Throw<DomainModelException>()
                .WithMessage("Specify a model.")
                .Which;

            exception.Root.Should().Be<Vehicle>();
            exception.Child.Should().Be<Model>();
        }

        [Fact]
        public void WhenTrimNotSpecified_ThrowException()
        {
            // Arrange
            Action action = () => Create(
                new VehicleId("id"),
                new Vin("vin"),
                new Year(2018),
                new Make("make"),
                new Model("model"), 
                null,
                new Exterior(),
                new Interior(),
                new Price(10000m, Currencies.UnitedStatesDollar),
                new Odometer(new MilesMeasurement(1000.5m, Units.Miles)));

            // Act & Assert
            var exception = action.Should().Throw<DomainModelException>()
                .WithMessage("Specify a trim.")
                .Which;

            exception.Root.Should().Be<Vehicle>();
            exception.Child.Should().Be<Trim>();
        }

        [Fact]
        public void WhenExteriorNotSpecified_ThrowException()
        {
            // Arrange
            Action action = () => Create(
                new VehicleId("id"),
                new Vin("vin"),
                new Year(2018),
                new Make("make"),
                new Model("model"),
                new Trim("trim"),
                null,
                new Interior(),
                new Price(10000m, Currencies.UnitedStatesDollar),
                new Odometer(new MilesMeasurement(1000.5m, Units.Miles)));

            // Act & Assert
            var exception = action.Should().Throw<DomainModelException>()
                .WithMessage("Specify an exterior object.")
                .Which;

            exception.Root.Should().Be<Vehicle>();
            exception.Child.Should().Be<Exterior>();
        }

        [Fact]
        public void WhenInteriorNotSpecified_ThrowException()
        {
            // Arrange
            Action action = () => Create(
                new VehicleId("id"),
                new Vin("vin"),
                new Year(2018),
                new Make("make"),
                new Model("model"),
                new Trim("trim"),
                new Exterior(), 
                null,
                new Price(10000m, Currencies.UnitedStatesDollar),
                new Odometer(new MilesMeasurement(1000.5m, Units.Miles)));

            // Act & Assert
            var exception = action.Should().Throw<DomainModelException>()
                .WithMessage("Specify an interior object.")
                .Which;

            exception.Root.Should().Be<Vehicle>();
            exception.Child.Should().Be<Interior>();
        }

        [Fact]
        public void WhenPriceNotSpecified_ThrowException()
        {
            // Arrange
            Action action = () => Create(
                new VehicleId("id"),
                new Vin("vin"),
                new Year(2018),
                new Make("make"),
                new Model("model"),
                new Trim("trim"),
                new Exterior(),
                new Interior(), 
                null,
                new Odometer(new MilesMeasurement(1000.5m, Units.Miles)));

            // Act & Assert
            var exception = action.Should().Throw<DomainModelException>()
                .WithMessage("Specify a price.")
                .Which;

            exception.Root.Should().Be<Vehicle>();
            exception.Child.Should().Be<Price>();
        }

        [Fact]
        public void WhenOdometerNotSpecified_ThrowException()
        {
            // Arrange
            Action action = () => Create(
                new VehicleId("id"),
                new Vin("vin"),
                new Year(2018),
                new Make("make"),
                new Model("model"),
                new Trim("trim"),
                new Exterior(),
                new Interior(),
                new Price(10000m, Currencies.UnitedStatesDollar), 
                null);

            // Act & Assert
            var exception = action.Should().Throw<DomainModelException>()
                .WithMessage("Specify an odometer object.")
                .Which;

            exception.Root.Should().Be<Vehicle>();
            exception.Child.Should().Be<Odometer>();
        }

        private static Vehicle CreateDefaultVehicle()
        {
            return Vehicle.Create(
                new VehicleId("id"), 
                new Vin("vin"),
                new Year(2018),
                new Make("make"),
                new Model("model"),
                new Trim("trim"),
                new Exterior(),
                new Interior(),
                new Price(10000m, Currencies.UnitedStatesDollar),
                new Odometer(new MilesMeasurement(1000.5m, Units.Miles)));
        }

        private static Vehicle Create(
            VehicleId id,
            Vin vin, 
            Year year,
            Make make,
            Model model,
            Trim trim,
            Exterior exterior,
            Interior interior,
            Price price,
            Odometer odometer)
        {
            return Vehicle.Create(
                id,
                vin,
                year,
                make,
                model,
                trim,
                exterior,
                interior,
                price,
                odometer);
        }
    }
}