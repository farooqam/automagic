using FluentAssertions;
using Xunit;

namespace Automagic.DomainModels.Vehicle.Tests
{
    public class InteriorTests
    {
        [Fact]
        public void GetTheColor()
        {
            // Arrange
            var interior = new Interior(Colors.Unknown);

            // Act
            var color = interior.Color;

            // Assert
            color.Should().Be(Colors.Unknown);
        }

        [Fact]
        public void DefaultColorShouldBeUnknown()
        {
            // Arrange
            var interior = new Interior();

            // Act
            var color = interior.Color;

            // Assert
            color.Should().Be(Colors.Unknown);
        }

        [Fact]
        public void Interiors_AreEqual()
        {
            // Arrange
            var interior1 = new Interior();
            var interior2 = new Interior();

            // Act
            var areEqual = interior1 == interior2;

            // Assert
            areEqual.Should().BeTrue();
        }

        [Fact]
        public void Interiors_WhenEqual_HashCodesEqual()
        {
            // Arrange
            var interior1 = new Interior();
            var interior2 = new Interior();

            // Act
            var hashCodesEqual = interior1.GetHashCode() == interior2.GetHashCode();

            // Assert
            hashCodesEqual.Should().BeTrue();
        }

        [Fact]
        public void Interiors_AreNotEqual()
        {
            // Arrange
            var interior1 = new Interior();
            var interior2 = new Interior(Colors.Black);

            // Act
            var areEqual = interior1 == interior2;

            // Assert
            areEqual.Should().BeFalse();
        }

        [Fact]
        public void Interiors_WhenNotEqual_HashCodesNotEqual()
        {
            // Arrange
            var interior1 = new Interior();
            var interior2 = new Interior(Colors.Black);

            // Act
            var hashCodesEqual = interior1.GetHashCode() == interior2.GetHashCode();

            // Assert
            hashCodesEqual.Should().BeFalse();
        }
    }
}
