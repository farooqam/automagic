using System;
using Automagic.DomainModels.Core;
using FluentAssertions;
using Xunit;

namespace Automagic.DomainModels.Vehicle.Tests
{
    public class OdometerTests
    {
        [Fact]
        public void GetTheMeasurement()
        {
            // Arrange
            var od = new Odometer(new MilesMeasurement(100m, Units.Miles));

            // Act
            var measurement = od.Measurement;

            // Assert
            measurement.Should().Be(new MilesMeasurement(100m, Units.Miles));
        }

        [Fact]
        public void Odometers_AreEqual()
        {
            // Arrange
            var od1 = new Odometer(new MilesMeasurement(100m, Units.Miles));
            var od2 = new Odometer(new MilesMeasurement(100m, Units.Miles));

            // Act
            var areEqual = od1 == od2;

            // Assert
            areEqual.Should().BeTrue();
        }

        [Fact]
        public void Odometers_WhenEqual_HashCodesEqual()
        {
            // Arrange
            var od1 = new Odometer(new MilesMeasurement(100m, Units.Miles));
            var od2 = new Odometer(new MilesMeasurement(100m, Units.Miles));

            // Act
            var hashCodesEqual = od1.GetHashCode() == od2.GetHashCode();

            // Assert
            hashCodesEqual.Should().BeTrue();
        }

        [Fact]
        public void Odometers_AreNotEqual()
        {
            // Arrange
            var od1 = new Odometer(new MilesMeasurement(100m, Units.Miles));
            var od2 = new Odometer(new MilesMeasurement(99m, Units.Miles));

            // Act
            var areEqual = od1 == od2;

            // Assert
            areEqual.Should().BeFalse();
        }

        [Fact]
        public void Odometers_WhenNotEqual_HashCodesNotEqual()
        {
            // Arrange
            var od1 = new Odometer(new MilesMeasurement(100m, Units.Miles));
            var od2 = new Odometer(new MilesMeasurement(99m, Units.Miles));

            // Act
            var hashCodesEqual = od1.GetHashCode() == od2.GetHashCode();

            // Assert
            hashCodesEqual.Should().BeFalse();
        }

        [Fact]
        public void WhenMeasurementNotSpecified_ThrowException()
        {
            // Arrange
            // ReSharper disable once ObjectCreationAsStatement
            Action action = () => new Odometer(null);

            // Act & Assert
            var exception = action.Should().Throw<DomainModelException>()
                .WithMessage("Specify a measurement.")
                .Which;

            exception.Root.Should().Be<Odometer>();
            exception.Child.Should().Be<Measurement>();
        }

    }
}