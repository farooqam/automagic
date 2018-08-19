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
        public void WhenVehicleIdNotSpecified_ThrowException()
        {
            // Arrange
            // ReSharper disable once ObjectCreationAsStatement
            Action action = () => Create(null, new Vin("vin"), new Year(2018), new Make("make"));

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
            var v1 = Create(new VehicleId("foo"), new Vin("vin"), new Year(2018), new Make("make"));
            var v2 = Create(new VehicleId("bar"), new Vin("vin"), new Year(2018), new Make("make"));

            // Act
            var areEqual = v1 == v2;

            // Assert
            areEqual.Should().BeFalse();
        }

        [Fact]
        public void Vehicles_WhenNotEqual_HashCodesNotEqual()
        {
            // Arrange
            var v1 = Create(new VehicleId("foo"), new Vin("vin"), new Year(2018), new Make("make"));
            var v2 = Create(new VehicleId("bar"), new Vin("vin"), new Year(2018), new Make("make"));

            // Act
            var hashCodesEqual = v1.GetHashCode() == v2.GetHashCode();

            // Assert
            hashCodesEqual.Should().BeFalse();
        }

        [Fact]
        public void WhenVinNotSpecified_ThrowException()
        {
            // Arrange
            Action action = () => Create(new VehicleId("id"), null, new Year(2018), new Make("make"));

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
            Action action = () => Create(new VehicleId("id"), new Vin("vin"), null, new Make("make"));

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
            Action action = () => Create(new VehicleId("id"), new Vin("vin"), new Year(2018), null);

            // Act & Assert
            var exception = action.Should().Throw<DomainModelException>()
                .WithMessage("Specify a make.")
                .Which;

            exception.Root.Should().Be<Vehicle>();
            exception.Child.Should().Be<Make>();
        }

        private static Vehicle CreateDefaultVehicle()
        {
            return Vehicle.Create(
                new VehicleId("id"), 
                new Vin("vin"),
                new Year(2018),
                new Make("make"));
        }

        private static Vehicle Create(
            VehicleId id,
            Vin vin, 
            Year year,
            Make make)
        {
            return Vehicle.Create(
                id,
                vin,
                year,
                make);
        }
    }
}