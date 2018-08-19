using System;
using Automagic.DomainModels.Core;
using FluentAssertions;
using Xunit;

namespace Automagic.DomainModels.Vehicle.Tests
{
    public class VinTests
    {
        [Fact]
        public void GetTheVin()
        {
            // Arrange
            var expectedValue = "abc123";
            var vin = new Vin(expectedValue);

            // Act
            var value = vin.Value;

            // Assert
            value.Should().Be(expectedValue);
        }

        [Fact]
        public void Vins_AreEqual()
        {
            // Arrange
            var vin1 = new Vin("abc123");
            var vin2 = new Vin("abc123");

            // Act
            var areEqual = vin1 == vin2;

            // Assert
            areEqual.Should().BeTrue();
        }

        [Fact]
        public void Vins_AreCaseInsensitive()
        {
            // Arrange
            var vin1 = new Vin("abc123");
            var vin2 = new Vin("ABC123");

            // Act
            var areEqual = vin1 == vin2;

            // Assert
            areEqual.Should().BeTrue();
        }

        [Fact]
        public void HashCodes_AreEqual()
        {
            // Arrange
            var vin1 = new Vin("abc123");
            var vin2 = new Vin("abc123");

            // Act
            var hashCodesEqual = vin1.GetHashCode() == vin2.GetHashCode();

            // Assert
            hashCodesEqual.Should().BeTrue();
        }

        [Fact]
        public void HashCodeCalculation_IsCaseInsensitive()
        {
            // Arrange
            var vin1 = new Vin("abc123");
            var vin2 = new Vin("ABC123");

            // Act
            var hashCodesEqual = vin1.GetHashCode() == vin2.GetHashCode();

            // Assert
            hashCodesEqual.Should().BeTrue();
        }

        [Fact]
        public void Vins_AreNotEqual()
        {
            // Arrange
            var vin1 = new Vin("abc123");
            var vin2 = new Vin("bc123");

            // Act
            var areEqual = vin1 == vin2;

            // Assert
            areEqual.Should().BeFalse();
        }

        [Fact]
        public void Vins_WhenNotEqual_HashCodesNotEqual()
        {
            // Arrange
            var vin1 = new Vin("abc123");
            var vin2 = new Vin("bc123");

            // Act
            var areEqual = vin1 == vin2;

            // Assert
            areEqual.Should().BeFalse();
        }

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