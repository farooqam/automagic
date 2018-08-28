using System;
using FluentAssertions;
using Xunit;

namespace Automagic.DomainModels.Core.Tests
{
    public sealed class EntityWithComplexIdTests
    {
        [Fact]
        public void GetTheIdValue()
        {
            // Arrange
            var expectedId = new FakeId(DateTime.Parse("08-18-2018 18:03:00"));
            var fakeEntity = new FakeEntityWithComplexId(expectedId);

            // Act
            var id = fakeEntity.Id;

            // Assert
            id.Value.Should().Be(expectedId.Value);
        }

        [Fact]
        public void EntitiesWithComplexIds_AreEqual()
        {
            // Arrange
            var e1 = new FakeEntityWithComplexId(new FakeId(DateTime.Parse("08-18-2018")));
            var e2 = new FakeEntityWithComplexId(new FakeId(DateTime.Parse("08-18-2018")));

            // Act
            var areEqual = e1 == e2;

            // Assert
            areEqual.Should().BeTrue();
        }

        [Fact]
        public void EntitiesWithComplexIds_WhenEqual_HaveEqualHashCodes()
        {
            // Arrange
            var e1 = new FakeEntityWithComplexId(new FakeId(DateTime.Parse("08-18-2018")));
            var e2 = new FakeEntityWithComplexId(new FakeId(DateTime.Parse("08-18-2018")));

            // Act
            var hashCodesEqual = e1.GetHashCode() == e2.GetHashCode();

            // Assert
            hashCodesEqual.Should().BeTrue();
        }

        [Fact]
        public void EntitiesWithComplexIds_AreNotEqual()
        {
            // Arrange
            var e1 = new FakeEntityWithComplexId(new FakeId(DateTime.Parse("08-19-2018")));
            var e2 = new FakeEntityWithComplexId(new FakeId(DateTime.Parse("08-18-2018")));

            // Act
            var areEqual = e1 == e2;

            // Assert
            areEqual.Should().BeFalse();
        }

        [Fact]
        public void EntitiesWithComplexIds_WhenNotEqual_HashCodesNotEqual()
        {
            // Arrange
            var e1 = new FakeEntityWithComplexId(new FakeId(DateTime.Parse("08-19-2018")));
            var e2 = new FakeEntityWithComplexId(new FakeId(DateTime.Parse("08-18-2018")));

            // Act
            var hashCodesEqual = e1.GetHashCode() == e2.GetHashCode();

            // Assert
            hashCodesEqual.Should().BeFalse();
        }

    }
    
    public class FakeEntityWithComplexId : Entity<FakeId>
    {
        public FakeEntityWithComplexId(FakeId id) : base(id)
        {
        }

        protected override HashCode CalculateHashCode()
        {
            return new HashCodeBuilder().Add(Id).Build();
        }

        protected override bool DoEqualityCheck(FakeId a, FakeId b)
        {
            return a == b;
        }
    }

    public class FakeId : ValueObject<FakeId>
    {
        public DateTime Value { get; }

        public FakeId(DateTime value)
        {
            Value = value;
        }
        
        protected override HashCode CalculateHashCode()
        {
            return new HashCodeBuilder().Add(Value).Build();
        }

        protected override bool DoEqualityCheck(FakeId a, FakeId b)
        {
            return a.Value == b.Value;
        }
    }
}
