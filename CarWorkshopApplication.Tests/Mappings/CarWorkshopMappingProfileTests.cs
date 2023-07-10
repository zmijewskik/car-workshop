using AutoMapper;
using CarWorkshopApplication.ApplicationUser;
using CarWorkshopApplication.CarWorkshop;
using CarWorkshopDomain.Entities;
using FluentAssertions;
using Moq;
using Xunit;

namespace CarWorkshopApplication.Mappings.Tests
{
    public class CarWorkshopMappingProfileTests
    {
        [Fact()]
        public void MappingProfile_ShouldMapCarWorkshopDtoToCarWorkshop()
        {
            // arrange
            var userContextMock = new Mock<IUserContext>();
            userContextMock.Setup(c => c.GetCurrentUser())
                .Returns(new CurrentUser("1", "test@test.com", new[] { "Moderator" }));

            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(new CarWorkshopMappingProfile(userContextMock.Object)));

            var mapper = configuration.CreateMapper();

            var dto = new CarWorkshopDto
            {
                City = "City",
                PhoneNumber = "111222333",
                PostalCode = "23-122",
                Street = "Kucza 33"
            };

            // act
            var result = mapper.Map<CarWorkshopDomain.Entities.CarWorkshop>(dto);

            // assert
            result.Should().NotBeNull();
            result.ContactDetails.Should().NotBeNull();
            result.ContactDetails.City.Should().Be(dto.City);
            result.ContactDetails.PhoneNumber.Should().Be(dto.PhoneNumber);
            result.ContactDetails.PostalCode.Should().Be(dto.PostalCode);
            result.ContactDetails.Street.Should().Be(dto.Street);

        }

        [Fact()]
        public void MappingProfile_ShouldMapCarWorkshopToCarWorkshopDto()
        {
            // arrange
            var userContextMock = new Mock<IUserContext>();
            userContextMock.Setup(c => c.GetCurrentUser())
                .Returns(new CurrentUser("1", "test@test.com", new[] { "Moderator" }));

            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(new CarWorkshopMappingProfile(userContextMock.Object)));

            var mapper = configuration.CreateMapper();

            var carWorkshop = new CarWorkshopDomain.Entities.CarWorkshop
            {
                Id = 1,
                CreatedById = "1",
                ContactDetails = new CarWorkshopContactDetails
                {
                    City = "City",
                    PhoneNumber = "111222333",
                    PostalCode = "23-122",
                    Street = "Kucza 33"
                }
            };

            // act
            var result = mapper.Map<CarWorkshopDto>(carWorkshop);

            // assert
            result.Should().NotBeNull();
            result.IsEditable.Should().BeTrue();
            result.City.Should().Be(carWorkshop.ContactDetails.City);
            result.PhoneNumber.Should().Be(carWorkshop.ContactDetails.PhoneNumber);
            result.PostalCode.Should().Be(carWorkshop.ContactDetails.PostalCode);
            result.Street.Should().Be(carWorkshop.ContactDetails.Street);

        }

        [Fact()]
        public void MappingProfile_ShouldNotMapCarWorkshopToCarWorkshopDto()
        {
            // arrange
            var userContextMock = new Mock<IUserContext>();
            userContextMock.Setup(c => c.GetCurrentUser())
                .Returns(new CurrentUser("2", "test@test.com", new[] { "User" }));

            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(new CarWorkshopMappingProfile(userContextMock.Object)));

            var mapper = configuration.CreateMapper();

            var carWorkshop = new CarWorkshopDomain.Entities.CarWorkshop
            {
                Id = 1,
                CreatedById = "1",
                ContactDetails = new CarWorkshopContactDetails
                {
                    City = "City",
                    PhoneNumber = "111222333",
                    PostalCode = "23-122",
                    Street = "Kucza 33"
                }
            };

            // act
            var result = mapper.Map<CarWorkshopDto>(carWorkshop);

            // assert
            result.Should().NotBeNull();
            result.IsEditable.Should().BeFalse();
            result.City.Should().Be(carWorkshop.ContactDetails.City);
            result.PhoneNumber.Should().Be(carWorkshop.ContactDetails.PhoneNumber);
            result.PostalCode.Should().Be(carWorkshop.ContactDetails.PostalCode);
            result.Street.Should().Be(carWorkshop.ContactDetails.Street);

        }
    }
}