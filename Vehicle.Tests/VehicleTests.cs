using System;
using Automagic.DomainModels.Core;
using FluentAssertions;
using Xunit;

namespace Automagic.DomainModels.Vehicle.Tests
{
    public class VehicleTests
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
        public void WhenVehicleIdNotSpecified_ThrowException()
        {
            // Arrange
            // ReSharper disable once ObjectCreationAsStatement
            Action action = () => Create(null, new Vin("vin"), new Year(2018), new Make("make"), new Model("model"));

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
            var v1 = Create(new VehicleId("foo"), new Vin("vin"), new Year(2018), new Make("make"), new Model("model"));
            var v2 = Create(new VehicleId("bar"), new Vin("vin"), new Year(2018), new Make("make"), new Model("model"));

            // Act
            var areEqual = v1 == v2;

            // Assert
            areEqual.Should().BeFalse();
        }

        [Fact]
        public void Vehicles_WhenNotEqual_HashCodesNotEqual()
        {
            // Arrange
            var v1 = Create(new VehicleId("foo"), new Vin("vin"), new Year(2018), new Make("make"), new Model("model"));
            var v2 = Create(new VehicleId("bar"), new Vin("vin"), new Year(2018), new Make("make"), new Model("model"));

            // Act
            var hashCodesEqual = v1.GetHashCode() == v2.GetHashCode();

            // Assert
            hashCodesEqual.Should().BeFalse();
        }

        [Fact]
        public void WhenVinNotSpecified_ThrowException()
        {
            // Arrange
            Action action = () => Create(new VehicleId("id"), null, new Year(2018), new Make("make"), new Model("model"));

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
            Action action = () => Create(new VehicleId("id"), new Vin("vin"), null, new Make("make"), new Model("model"));

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
            Action action = () => Create(new VehicleId("id"), new Vin("vin"), new Year(2018), null, new Model("model"));

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
            Action action = () => Create(new VehicleId("id"), new Vin("vin"), new Year(2018), new Make("make"), null);

            // Act & Assert
            var exception = action.Should().Throw<DomainModelException>()
                .WithMessage("Specify a model.")
                .Which;

            exception.Root.Should().Be<Vehicle>();
            exception.Child.Should().Be<Model>();
        }

        private static Vehicle CreateDefaultVehicle()
        {
            return Vehicle.Create(
                new VehicleId("id"), 
                new Vin("vin"),
                new Year(2018),
                new Make("make"),
                new Model("model"));
        }

        private static Vehicle Create(
            VehicleId id,
            Vin vin, 
            Year year,
            Make make,
            Model model)
        {
            return Vehicle.Create(
                id,
                vin,
                year,
                make,
                model);
        }
    }
}