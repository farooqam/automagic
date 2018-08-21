using System;
using FluentAssertions;
using Xunit;

namespace Automagic.DomainModels.Core.Tests
{
    public class CurrencyAbbreviationTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void WhenAbbreviationNotSpecified_ThrowException(string value)
        {
            // Arrange
            // ReSharper disable once ObjectCreationAsStatement
            Action action = () => new CurrencyAbbreviation(value);

            // Act and Assert
            var exception = action.Should().Throw<DomainModelException>()
                .WithMessage("Specify an abbreviation.")
                .Which;

            exception.Root.Should().Be<CurrencyAbbreviation>();
            exception.Child.Should().BeNull();
        }
    }
}
