using System;
using Automagic.DomainModels.Core;
using FluentAssertions;
using Xunit;

namespace Automagic.DomainModels.Vehicle.Tests
{
    public sealed class ModelTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void WhenValueNotSpecified_ThrowException(string value)
        {
            // Arrange
            // ReSharper disable once ObjectCreationAsStatement
            Action action = () => { new Model(value); };

            // Act & Assert
            var exception = action.Should().Throw<DomainModelException>()
                .WithMessage("Specify a model.")
                .Which;

            exception.Root.Should().Be<Model>();
            exception.Child.Should().BeNull();


        }
    }
}