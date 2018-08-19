using FluentAssertions;
using Xunit;

namespace Automagic.DomainModels.Core.Tests
{
    public class CurrencyTests
    {
        [Fact]
        public void GetTheAbbreviation()
        {
            // Arrange
            var currency = Currencies.UnitedStatesDollar;

            // Act
            var abbr = currency.Abbreviation;

            // Assert
            abbr.Should().Be(new CurrencyAbbreviation("USD"));

        }

        [Fact]
        public void Currencies_AreEqual()
        {
            // Arrange
            var c1 = Currencies.UnitedStatesDollar;
            var c2 = Currencies.UnitedStatesDollar;
            
            // Act
            var areEqual = c1 == c2;

            // Assert
            areEqual.Should().BeTrue();

        }

        [Fact]
        public void Currencies_WhenEqual_HaveEqualHashCodes()
        {
            // Arrange
            var c1 = Currencies.UnitedStatesDollar;
            var c2 = Currencies.UnitedStatesDollar;

            // Act
            var hashCodesEqual = c1.GetHashCode() == c2.GetHashCode();

            // Assert
            hashCodesEqual.Should().BeTrue();

        }
    }
}
