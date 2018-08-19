using FluentAssertions;
using Xunit;

namespace Automagic.DomainModels.Core.Tests
{
    public class EntityWithPrimitiveIdTests
    {
        [Fact]
        public void GetTheIdValue()
        {
            // Arrange
            var expectedId = 100;
            var fakeEntity = new FakeEntityWithPrimitiveId(expectedId);

            // Act
            var id = fakeEntity.Id;

            // Assert
            id.Should().Be(expectedId);
        }

        [Fact]
        public void EntitiesWithPrimitiveIds_AreEqual()
        {
            // Arrange
            var e1 = new FakeEntityWithPrimitiveId(1000);
            var e2 = new FakeEntityWithPrimitiveId(1000);

            // Act
            var areEqual = e1 == e2;

            // Assert
            areEqual.Should().BeTrue();
        }

        [Fact]
        public void EntitiesWithPrimitiveIds_WhenEqual_HaveEqualHashCodes()
        {
            // Arrange
            var e1 = new FakeEntityWithPrimitiveId(1000);
            var e2 = new FakeEntityWithPrimitiveId(1000);

            // Act
            var hashCodesEqual = e1.GetHashCode() == e2.GetHashCode();

            // Assert
            hashCodesEqual.Should().BeTrue();
        }

        [Fact]
        public void EntitiesWithPrimitiveIds_AreNotEqual()
        {
            // Arrange
            var e1 = new FakeEntityWithPrimitiveId(1000);
            var e2 = new FakeEntityWithPrimitiveId(1001);

            // Act
            var areEqual = e1 == e2;

            // Assert
            areEqual.Should().BeFalse();
        }

        [Fact]
        public void EntitiesWithPrimitiveIds_WhenNotEqual_HashCodesNotEqual()
        {
            // Arrange
            var e1 = new FakeEntityWithPrimitiveId(1000);
            var e2 = new FakeEntityWithPrimitiveId(1001);

            // Act
            var hashCodesEqual = e1.GetHashCode() == e2.GetHashCode();

            // Assert
            hashCodesEqual.Should().BeFalse();
        }

    }

    public class FakeEntityWithPrimitiveId : Entity<int>
    {
        public FakeEntityWithPrimitiveId(int id) : base(id)
        {
        }

        protected override HashCode CalculateHashCode()
        {
            return new HashCode(Id.GetHashCode());
        }

        protected override bool DoEqualityCheck(int a, int b)
        {
            return a == b;
        }
    }
}
