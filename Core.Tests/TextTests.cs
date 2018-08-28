using FluentAssertions;
using Xunit;

namespace Automagic.DomainModels.Core.Tests
{
    public sealed class TextTests
    {
        [Fact]
        public void GetTheValue()
        {
            // Arrange
            var expectedValue = "foo";
            var text = new FakeText(expectedValue);

            // Act
            var value = text.Value;

            // Assert
            value.Should().Be(expectedValue);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]
        public void ValueCanBeNullOrWhitespace(string expectedValue)
        {
            // Arrange
            var text = new FakeText(expectedValue);

            // Act
            var actualValue = text.Value;

            // Assert
            actualValue.Should().Be(expectedValue);
        }

        [Fact]
        public void Texts_AreEqual()
        {
            // Arrange
            var t1 = new FakeText("foo");
            var t2 = new FakeText("foo");

            // Act
            var areEqual = t1 == t2;

            // Assert
            areEqual.Should().BeTrue();

        }

        [Fact]
        public void Texts_WhenEqual_HaveEqualHashCodes()
        {
            // Arrange
            var t1 = new FakeText("foo");
            var t2 = new FakeText("foo");

            // Act
            var hashCodesEqual = t1.GetHashCode() == t2.GetHashCode();

            // Assert
            hashCodesEqual.Should().BeTrue();

        }

        [Fact]
        public void HashCodeCalculation_IsCaseInsensitive()
        {
            // Arrange
            var t1 = new FakeText("foo");
            var t2 = new FakeText("FOO");

            // Act
            var hashCodesEqual = t1.GetHashCode() == t2.GetHashCode();

            // Assert
            hashCodesEqual.Should().BeTrue();

        }

        [Fact]
        public void Texts_AreCaseInsensitive()
        {
            // Arrange
            var t1 = new FakeText("foo");
            var t2 = new FakeText("FOO");

            // Act
            var areEqual = t1 == t2;

            // Assert
            areEqual.Should().BeTrue();

        }

        [Fact]
        public void Texts_AreNotEqual()
        {
            // Arrange
            var t1 = new FakeText("foo");
            var t2 = new FakeText("bar");

            // Act
            var areEqual = t1 == t2;

            // Assert
            areEqual.Should().BeFalse();

        }

        [Fact]
        public void Texts_WhenNotEqual_HashCodesNotEqual()
        {
            // Arrange
            var t1 = new FakeText("foo");
            var t2 = new FakeText("bar");

            // Act
            var hashCodesEqual = t1.GetHashCode() == t2.GetHashCode();

            // Assert
            hashCodesEqual.Should().BeFalse();

        }
    }

    public class FakeText : Text
    {
        public FakeText(string value) : base(value)
        {
        }
    }
}