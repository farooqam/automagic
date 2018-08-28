using System;
using FluentAssertions;
using Xunit;

namespace Automagic.DomainModels.Core.Tests
{
    public sealed class MilesMeasurementTests
    {
        [Fact]
        public void WhenValueNegative_ThrowException()
        {
            // Arrange
            // ReSharper disable once ObjectCreationAsStatement
            Action action = () => new MilesMeasurement(-1m, Units.Miles);

            // Act & Assert
            var exception = action.Should().Throw<DomainModelException>()
                .WithMessage("Measurement value cannot be less than zero.")
                .Which;

            exception.Root.Should().Be<MilesMeasurement>();
            exception.Child.Should().BeNull();
        }
    }
}