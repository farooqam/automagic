using FluentAssertions;
using Xunit;

namespace Automagic.DomainModels.Core.Tests
{
    public class ValueObjectTests
    {
        [Fact]
        public void ValueObjects_AreEqual()
        {
            // Arrange
            var vo1 = new FakeValueObject(1, 2, 3);
            var vo2 = new FakeValueObject(1, 2, 3);

            // Act
            var areEqual = vo1 == vo2;

            // Assert
            areEqual.Should().BeTrue();
        }

        [Fact]
        public void ValueObjects_WhenEqual_HaveEqualHashCodes()
        {
            // Arrange
            var vo1 = new FakeValueObject(1, 2, 3);
            var vo2 = new FakeValueObject(1, 2, 3);

            // Act
            var hashCodesEqual = vo1.GetHashCode() == vo2.GetHashCode();

            // Assert
            hashCodesEqual.Should().BeTrue();
        }

        [Fact]
        public void ValueObjects_AreNotEqual()
        {
            // Arrange
            var vo1 = new FakeValueObject(1, 2, 3);
            var vo2 = new FakeValueObject(2, 2, 3);

            // Act
            var areEqual = vo1 == vo2;

            // Assert
            areEqual.Should().BeFalse();
        }

        [Fact]
        public void ValueObjects_WhenNotEqual_HashCodesNotEqual()
        {
            // Arrange
            var vo1 = new FakeValueObject(1, 2, 3);
            var vo2 = new FakeValueObject(2, 2, 3);

            // Act
            var hashCodesEqual = vo1.GetHashCode() == vo2.GetHashCode();

            // Assert
            hashCodesEqual.Should().BeFalse();
        }
    }

    public class FakeValueObject : ValueObject<FakeValueObject>
    {
        public int X { get; }

        public int Y { get; }

        public int Z { get; }

        public FakeValueObject(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        protected override HashCode CalculateHashCode()
        {
            return new HashCode(X.GetHashCode() ^ Y.GetHashCode() ^ Z.GetHashCode());
        }

        protected override bool DoEqualityCheck(FakeValueObject a, FakeValueObject b)
        {
            return a.X == b.X &&
                   a.Y == b.Y &&
                   a.Z == b.Z;
        }
    }
}