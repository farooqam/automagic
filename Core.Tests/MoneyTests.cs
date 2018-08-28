using System;
using FluentAssertions;
using Xunit;

namespace Automagic.DomainModels.Core.Tests
{
    public sealed class MoneyTests
    {
        [Fact]
        public void GetTheAmount()
        {
            // Arrange
            var expectedAmount = 100.50m;
            var currency = Currencies.UnitedStatesDollar;
            var money = new FakeMoney(expectedAmount, currency);

            // Act
            var actualAmount = money.Amount;

            // Assert
            actualAmount.Should().Be(expectedAmount);
        }

        [Fact]
        public void GetTheCurrency()
        {
            // Arrange
            var amount = 100.50m;
            var expectedCurrency = Currencies.UnitedStatesDollar;
            var money = new FakeMoney(amount, expectedCurrency);

            // Act
            var actualCurrency = money.Currency;

            // Assert
            actualCurrency.Should().Be(Currencies.UnitedStatesDollar);
        }

        [Fact]
        public void WhenCurrencyNotSpecified_ThrowException()
        {
            // Arrange
            // ReSharper disable once ObjectCreationAsStatement
            Action action = () => new FakeMoney(100m, null);

            // Act & Assert
            var exception = action.Should().Throw<DomainModelException>()
                .WithMessage("Specify a currency.")
                .Which;

            exception.Root.Should().Be<Money>();
            exception.Child.Should().Be<Currency>();
        }

        [Fact]
        public void Monies_AreEqual()
        {
            // Arrange
            var m1 = new FakeMoney(100m, Currencies.UnitedStatesDollar);
            var m2 = new FakeMoney(100m, Currencies.UnitedStatesDollar);

            // Act
            var areEqual = m1 == m2;

            // Assert
            areEqual.Should().BeTrue();
        }

        [Fact]
        public void Monies_WhenEqual_HaveEqualHashCodes()
        {
            // Arrange
            var m1 = new FakeMoney(100m, Currencies.UnitedStatesDollar);
            var m2 = new FakeMoney(100m, Currencies.UnitedStatesDollar);

            // Act
            var hashCodesEqual = m1.GetHashCode() == m2.GetHashCode();

            // Assert
            hashCodesEqual.Should().BeTrue();
        }

        [Fact]
        public void Monies_AreNotEqual()
        {
            // Arrange
            var m1 = new FakeMoney(100m, Currencies.UnitedStatesDollar);
            var m2 = new FakeMoney(101m, Currencies.UnitedStatesDollar);

            // Act
            var areEqual = m1 == m2;

            // Assert
            areEqual.Should().BeFalse();
        }

        [Fact]
        public void Monies_WhenNotEqual_HashCodesNotEqual()
        {
            // Arrange
            var m1 = new FakeMoney(100m, Currencies.UnitedStatesDollar);
            var m2 = new FakeMoney(101m, Currencies.UnitedStatesDollar);

            // Act
            var hashCodesEqual = m1.GetHashCode() == m2.GetHashCode();

            // Assert
            hashCodesEqual.Should().BeFalse();
        }
    }

    public sealed class FakeMoney: Money
    {
        public FakeMoney(decimal amount, Currency currency) : base(amount, currency)
        {
        }
    }
}
