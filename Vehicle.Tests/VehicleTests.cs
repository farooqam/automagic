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
            var vehicle = new Vehicle(new VehicleId("foo"));

            // Act
            var id = vehicle.Id;

            // Assert
            id.Should().Be(new VehicleId("foo"));
        }

        [Fact]
        public void WhenVehicleIdNotSpecified_ThrowException()
        {
            // Arrange
            // ReSharper disable once ObjectCreationAsStatement
            Action action = () => new Vehicle(null);

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
            var v1 = new Vehicle(new VehicleId("foo"));
            var v2 = new Vehicle(new VehicleId("foo"));

            // Act
            var areEqual = v1 == v2;

            // Assert
            areEqual.Should().BeTrue();
        }

        [Fact]
        public void Vehicles_WhenEqual_HaveSameHashCode()
        {
            // Arrange
            var v1 = new Vehicle(new VehicleId("foo"));
            var v2 = new Vehicle(new VehicleId("foo"));

            // Act
            var hashCodesEqual = v1.GetHashCode() == v2.GetHashCode();

            // Assert
            hashCodesEqual.Should().BeTrue();
        }

        [Fact]
        public void Vehicles_AreNotEqual()
        {
            // Arrange
            var v1 = new Vehicle(new VehicleId("foo"));
            var v2 = new Vehicle(new VehicleId("bar"));

            // Act
            var areEqual = v1 == v2;

            // Assert
            areEqual.Should().BeFalse();
        }

        [Fact]
        public void Vehicles_WhenNotEqual_HashCodesNotEqual()
        {
            // Arrange
            var v1 = new Vehicle(new VehicleId("foo"));
            var v2 = new Vehicle(new VehicleId("bar"));

            // Act
            var hashCodesEqual = v1.GetHashCode() == v2.GetHashCode();

            // Assert
            hashCodesEqual.Should().BeFalse();
        }
    }
}