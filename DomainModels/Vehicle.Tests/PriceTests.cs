using System;
using Automagic.DomainModels.Core;
using FluentAssertions;
using Xunit;

namespace Automagic.DomainModels.Vehicle.Tests
{
    public class PriceTests
    {
        [Fact]
        public void WhenPriceNegative_ThrowException()
        {
            // Arrange
            // ReSharper disable once ObjectCreationAsStatement
            Action action = () => new Price(-1, Currencies.UnitedStatesDollar);

            // Act & Assert
            var exception = action.Should().Throw<DomainModelException>()
                .WithMessage("Amount cannot be less than zero.")
                .Which;

            exception.Root.Should().Be<Price>();
            exception.Child.Should().BeNull();
        }
    }
}
