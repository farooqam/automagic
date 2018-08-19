using System;
using Automagic.DomainModels.Core;
using FluentAssertions;
using Xunit;

namespace Automagic.DomainModels.Vehicle.Tests
{
    public class VehicleIdTests
    {
        [Fact]
        public void Ids_AreEqual()
        {
            // Arrange
            var id1 = new VehicleId("foo");
            var id2 = new VehicleId("foo");

            // Act
            var areEqual = id1 == id2;

            // Assert
            areEqual.Should().BeTrue();

        }

        [Fact]
        public void Ids_WhenEqual_HaveSameHashCode()
        {
            // Arrange
            var id1 = new VehicleId("foo");
            var id2 = new VehicleId("foo");

            // Act
            var hashCodesEqual = id1.GetHashCode() == id2.GetHashCode();

            // Assert
            hashCodesEqual.Should().BeTrue();

        }

        [Fact]
        public void Ids_WhenContentSame_ButCaseDiffers_HaveSameHashCode()
        {
            // Arrange
            var id1 = new VehicleId("foo");
            var id2 = new VehicleId("FOO");

            // Act
            var hashCodesEqual = id1.GetHashCode() == id2.GetHashCode();

            // Assert
            hashCodesEqual.Should().BeTrue();

        }

        [Fact]
        public void Ids_AreNotEqual()
        {
            // Arrange
            var id1 = new VehicleId("foo");
            var id2 = new VehicleId("bar");

            // Act
            var areEqual = id1 == id2;

            // Assert
            areEqual.Should().BeFalse();

        }

        [Fact]
        public void Ids_WhenNotEqual_HashCodeNotEqual()
        {
            // Arrange
            var id1 = new VehicleId("foo");
            var id2 = new VehicleId("bar");

            // Act
            var hashCodesEqual = id1.GetHashCode() == id2.GetHashCode();

            // Assert
            hashCodesEqual.Should().BeFalse();

        }

        [Fact]
        public void Ids_AreCaseInsensitive()
        {
            // Arrange
            var id1 = new VehicleId("foo");
            var id2 = new VehicleId("FOO");

            // Act
            var areEqual = id1 == id2;

            // Assert
            areEqual.Should().BeTrue();

        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void WhenIdNotSpecified_ThrowException(string id)
        {
            // Arrange
            // ReSharper disable once ObjectCreationAsStatement
            Action action = () => { new VehicleId(id); };

            // Act & Assert
            var exception = action.Should().Throw<DomainModelException>()
                .WithMessage("Specify a vehicle id.")
                .Which;

            exception.Root.Should().Be<VehicleId>();
            exception.Child.Should().BeNull();


        }
    }
}
