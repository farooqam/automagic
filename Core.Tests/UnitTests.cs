using FluentAssertions;
using Xunit;

namespace Automagic.DomainModels.Core.Tests
{
    public sealed class UnitTests
    {
        [Fact]
        public void GetTheAbbreviation()
        {
            // Arrange
            var unit = Units.Miles;

            // Act
            var abbr = unit.Abbreviation;

            // Assert
            abbr.Should().Be(new UnitAbbreviation("mi"));
        }

        [Fact]
        public void Units_AreEqual()
        {
            // Arrange
            var u1 = Units.Miles;
            var u2 = Units.Miles;

            // Act
            var areEqual = u1 == u2;

            // Assert
            areEqual.Should().BeTrue();
        }

        [Fact]
        public void Units_WhenEqual_HashCodesAreEqual()
        {
            // Arrange
            var u1 = Units.Miles;
            var u2 = Units.Miles;

            // Act
            var hashCodesEqual = u1.GetHashCode() == u2.GetHashCode();

            // Assert
            hashCodesEqual.Should().BeTrue();
        }
    }
}
