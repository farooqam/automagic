using System;
using Automagic.DomainModels.Core;
using FluentAssertions;
using Xunit;

namespace Automagic.DomainModels.Vehicle.Tests
{
    public class YearTests
    {
        [Fact]
        public void GetTheValue()
        {
            // Arrange
            short expectedValue = 2018;
            var year = new Year(expectedValue);

            // Act
            var value = year.Value;

            // Assert
            value.Should().Be(expectedValue);
        }
        [Fact]
        public void Years_AreEqual()
        {
            // Arrange
            var y1 = new Year(2018);
            var y2 = new Year(2018);

            // Act
            var areEqual = y1 == y2;

            // Assert
            areEqual.Should().BeTrue();
        }

        [Fact]
        public void Years_WhenEqual_HaveEqualHashCodes()
        {
            // Arrange
            var y1 = new Year(2018);
            var y2 = new Year(2018);

            // Act
            var hashCodesEqual = y1.GetHashCode() == y2.GetHashCode();

            // Assert
            hashCodesEqual.Should().BeTrue();
        }

        [Fact]
        public void Years_AreNotEqual()
        {
            // Arrange
            var y1 = new Year(2018);
            var y2 = new Year(2017);

            // Act
            var areEqual = y1 == y2;

            // Assert
            areEqual.Should().BeFalse();
        }

        [Fact]
        public void Years_WhenNotEqual_HashCodesNotEqual()
        {
            // Arrange
            var y1 = new Year(2018);
            var y2 = new Year(2017);

            // Act
            var hashCodesEqual = y1.GetHashCode() == y2.GetHashCode();

            // Assert
            hashCodesEqual.Should().BeFalse();
        }

        [Theory]
        [InlineData(1899)]
        [InlineData(2019)]
        public void WhenYearOutOfRange_ThrowException(short value)
        {
            // Arrange
            // ReSharper disable once ObjectCreationAsStatement
            Action action = () => new Year(value);

            // Act & Assert
            var exception = action.Should().Throw<DomainModelException>()
                .WithMessage($"Year must be between {Year.Min} and {Year.Max}.")
                .Which;

            exception.Root.Should().Be<Year>();
            exception.Child.Should().BeNull();


        }
    }
}
