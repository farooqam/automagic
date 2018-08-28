using System;
using Automagic.DomainModels.Core;
using FluentAssertions;
using Xunit;

namespace Automagic.DomainModels.Vehicle.Tests
{
    public sealed class MakeTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void WhenValueNotSpecified_ThrowException(string value)
        {
            // Arrange
            // ReSharper disable once ObjectCreationAsStatement
            Action action = () => { new Make(value); };

            // Act & Assert
            var exception = action.Should().Throw<DomainModelException>()
                .WithMessage("Specify a make.")
                .Which;

            exception.Root.Should().Be<Make>();
            exception.Child.Should().BeNull();


        }
    }
}