using System;
using Automagic.DomainModels.Core;
using FluentAssertions;
using Xunit;

namespace Automagic.DomainModels.Vehicle.Tests
{
    public sealed class VehicleIdTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void WhenIdNotSpecified_ThrowException(string id)
        {
            // Arrange
            // ReSharper disable once ObjectCreationAsStatement
            Action action = () => { new VehicleId(id); };

            // Act & Assert
            var exception = action.Should().Throw<DomainModelException>()
                .WithMessage("Specify a vehicle id.")
                .Which;

            exception.Root.Should().Be<VehicleId>();
            exception.Child.Should().BeNull();


        }
    }
}
