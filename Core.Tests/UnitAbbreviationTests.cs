using System;
using FluentAssertions;
using Xunit;

namespace Automagic.DomainModels.Core.Tests
{
    public sealed class UnitAbbreviationTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void WhenAbbreviationNotSpecified_ThrowException(string value)
        {
            // Arrange
            // ReSharper disable once ObjectCreationAsStatement
            Action action = () => new UnitAbbreviation(value);

            // Act & Assert
            var exception = action.Should().Throw<DomainModelException>()
                .WithMessage("Specify the abbreviation.")
                .Which;

            exception.Root.Should().Be<UnitAbbreviation>();
            exception.Child.Should().BeNull();
        }
    }
}
