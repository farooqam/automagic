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
        public void WhenVehicleIdNotSpecified_ThrowException()
        {
            // Arrange
            // ReSharper disable once ObjectCreationAsStatement
            Action action = () => Create(null, new Vin("vin"));

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
            var v1 = Create(new VehicleId("foo"), new Vin("vin"));
            var v2 = Create(new VehicleId("bar"), new Vin("vin"));

            // Act
            var areEqual = v1 == v2;

            // Assert
            areEqual.Should().BeFalse();
        }

        [Fact]
        public void Vehicles_WhenNotEqual_HashCodesNotEqual()
        {
            // Arrange
            var v1 = Create(new VehicleId("foo"), new Vin("vin"));
            var v2 = Create(new VehicleId("bar"), new Vin("vin"));

            // Act
            var hashCodesEqual = v1.GetHashCode() == v2.GetHashCode();

            // Assert
            hashCodesEqual.Should().BeFalse();
        }

        [Fact]
        public void WhenVinNotSpecified_ThrowException()
        {
            // Arrange
            Action action = () => Create(new VehicleId("id"), null);

            // Act & Assert
            var exception = action.Should().Throw<DomainModelException>()
                .WithMessage("Specify a vin.")
                .Which;

            exception.Root.Should().Be<Vehicle>();
            exception.Child.Should().Be<Vin>();
        }

        private static Vehicle CreateDefaultVehicle()
        {
            return Vehicle.Create(
                new VehicleId("id"), 
                new Vin("vin"));
        }

        private static Vehicle Create(
            VehicleId id,
            Vin vin)
        {
            return Vehicle.Create(
                id,
                vin);
        }
    }
}