using System;
using Automagic.DomainModels.Core;
using FluentAssertions;
using Xunit;

namespace Automagic.DomainModels.Vehicle.Tests
{
    public class VinTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]
        public void WhenVinValueNotSpecified_ThrowException(string value)
        {
            // Arrange
            // ReSharper disable once ObjectCreationAsStatement
            Action action = () => new Vin(value);

            // Act & Assert
            var exception = action.Should().Throw<DomainModelException>()
                .WithMessage("Specify a vin.")
                .Which;

            exception.Root.Should().Be<Vin>();
            exception.Child.Should().BeNull();
        }
    }
}