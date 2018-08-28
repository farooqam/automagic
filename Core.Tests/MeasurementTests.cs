using System;
using FluentAssertions;
using Xunit;

namespace Automagic.DomainModels.Core.Tests
{
    public sealed class MeasurementTests
    {
        [Fact]
        public void GetTheValue()
        {
            // Arrange
            var expectedValue = 100.5m;
            var measurement = new FakeMeasurement(expectedValue, Units.Miles);

            // Act
            var actualValue = measurement.Value;

            // Assert
            actualValue.Should().Be(expectedValue);
        }

        [Fact]
        public void GetTheUnit()
        {
            // Arrange
            var measurement = new FakeMeasurement(100.5m, Units.Miles);

            // Act
            var unit = measurement.Unit;

            // Assert
            unit.Should().Be(Units.Miles);
        }

        [Fact]
        public void Measurements_AreEqual()
        {
            // Arrange
            var m1 = new FakeMeasurement(100.5m, Units.Miles);
            var m2 = new FakeMeasurement(100.5m, Units.Miles);

            // Act
            var areEqual = m1 == m2;

            // Assert
            areEqual.Should().BeTrue();
        }

        [Fact]
        public void Measurements_WhenEqual_HaveSameHashCode()
        {
            // Arrange
            var m1 = new FakeMeasurement(100.5m, Units.Miles);
            var m2 = new FakeMeasurement(100.5m, Units.Miles);

            // Act
            var hashCodesEqual = m1.GetHashCode() == m2.GetHashCode();

            // Assert
            hashCodesEqual.Should().BeTrue();
        }

        [Fact]
        public void Measurements_AreNotEqual()
        {
            // Arrange
            var m1 = new FakeMeasurement(100.5m, Units.Miles);
            var m2 = new FakeMeasurement(99.5m, Units.Miles);

            // Act
            var areEqual = m1 == m2;

            // Assert
            areEqual.Should().BeFalse();
        }

        [Fact]
        public void Measurements_WhenNotEqual_HashCodesNotEqual()
        {
            // Arrange
            var m1 = new FakeMeasurement(100.5m, Units.Miles);
            var m2 = new FakeMeasurement(99.5m, Units.Miles);

            // Act
            var hashCodesEqual = m1.GetHashCode() == m2.GetHashCode();

            // Assert
            hashCodesEqual.Should().BeFalse();
        }

        [Fact]
        public void WhenUnitNotSpecified_ThrowException()
        {
            // Arrange
            // ReSharper disable once ObjectCreationAsStatement
            Action action = () => new FakeMeasurement(100m, null);

            // Act & Assert
            var exception = action.Should().Throw<DomainModelException>()
                .WithMessage("Specify the unit.")
                .Which;

            exception.Root.Should().Be<FakeMeasurement>();
            exception.Child.Should().Be<Unit>();


        }
    }

    public class FakeMeasurement : Measurement
    {
        public FakeMeasurement(decimal value, Unit unit) : base(value, unit)
        {
        }
    }
}