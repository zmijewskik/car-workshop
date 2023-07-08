using Xunit;
using FluentAssertions;

namespace CarWorkshopDomain.Entities.Tests
{
    public class CarWorkshopTests
    {
        [Fact()]
        public void EncodeName_ShouldSetEncodedName()
        {
            // arrange
            var carWorkshop = new CarWorkshop();
            carWorkshop.Name = "Test Workshop";

            // act
            carWorkshop.EncodeName();

            // assert
            carWorkshop.EncodedName.Should().Be("test-workshop");
        }

        [Fact()]
        public void EncodeName_ShouldThrowException_WhenNameIsNull()
        {
            // arrange
            var carWorkshop = new CarWorkshop();

            // act
            Action action = () => carWorkshop.EncodeName();

            // assert
            action.Invoking(a => a.Invoke())
                .Should().Throw<NullReferenceException>();
        }
    }
}