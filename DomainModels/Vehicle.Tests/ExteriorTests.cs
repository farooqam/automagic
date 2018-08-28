using FluentAssertions;
using Xunit;

namespace Automagic.DomainModels.Vehicle.Tests
{
    public class ExteriorTests
    {
        [Fact]
        public void GetTheColor()
        {
            // Arrange
            var exterior = new Exterior(Colors.Unknown);

            // Act
            var color = exterior.Color;

            // Assert
            color.Should().Be(Colors.Unknown);
        }

        [Fact]
        public void DefaultColorShouldBeUnknown()
        {
            // Arrange
            var exterior = new Exterior();

            // Act
            var color = exterior.Color;

            // Assert
            color.Should().Be(Colors.Unknown);
        }

        [Fact]
        public void Exteriors_AreEqual()
        {
            // Arrange
            var exterior1 = new Exterior();
            var exterior2 = new Exterior();

            // Act
            var areEqual = exterior1 == exterior2;

            // Assert
            areEqual.Should().BeTrue();
        }

        [Fact]
        public void Exteriors_WhenEqual_HashCodesEqual()
        {
            // Arrange
            var exterior1 = new Exterior();
            var exterior2 = new Exterior();

            // Act
            var hashCodesEqual = exterior1.GetHashCode() == exterior2.GetHashCode();

            // Assert
            hashCodesEqual.Should().BeTrue();
        }

        [Fact]
        public void Exteriors_AreNotEqual()
        {
            // Arrange
            var exterior1 = new Exterior();
            var exterior2 = new Exterior(Colors.Black);

            // Act
            var areEqual = exterior1 == exterior2;

            // Assert
            areEqual.Should().BeFalse();
        }

        [Fact]
        public void Exteriors_WhenNotEqual_HashCodesNotEqual()
        {
            // Arrange
            var exterior1 = new Exterior();
            var exterior2 = new Exterior(Colors.Black);

            // Act
            var hashCodesEqual = exterior1.GetHashCode() == exterior2.GetHashCode();

            // Assert
            hashCodesEqual.Should().BeFalse();
        }
    }
}
