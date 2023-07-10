using CarWorkshopApplication.CarWorkshop;
using CarWorkshopApplication.CarWorkshop.Queries.GetAllCarWorkshops;
using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Moq;
using System.Net;
using Xunit;

namespace CarWorkshopMVC.Controllers.Tests
{
    public class CarWorkshopControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> factory;

        public CarWorkshopControllerTests(WebApplicationFactory<Program> factory)
        {
            this.factory = factory;
        }

        [Fact()]
        public async Task Index_ReturnsViewWithExpectedData_ForExistingWorkshops()
        {
            // arrange
            var carWorkshops = new List<CarWorkshopDto>()
            {
                new CarWorkshopDto()
                {
                    Name = "CarWorkshop 1",
                },
                new CarWorkshopDto()
                {
                    Name = "CarWorkshop 2",
                },
                new CarWorkshopDto()
                {
                    Name = "CarWorkshop 3",
                },
            };

            var mediatorMock = new Mock<IMediator>();
            mediatorMock.Setup(m => m.Send(It.IsAny<GetAllCarWorkshopsQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(carWorkshops);

            var client = factory
                .WithWebHostBuilder(builder =>
                    builder.ConfigureTestServices(services => services.AddScoped(_ => mediatorMock.Object)))
                .CreateClient();

            // act
            var response = await client.GetAsync("/CarWorkshop/Index");

            // assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var content = await response.Content.ReadAsStringAsync();

            content.Should().Contain("<h1>Car Workshops</h1>")
                .And.Contain("CarWorkshop 1")
                .And.Contain("CarWorkshop 2")
                .And.Contain("CarWorkshop 3");

        }

        [Fact()]
        public async Task Index_ReturnsEmptyView_WhenNoCarWorkshopExist()
        {
            // arrange
            var carWorkshops = new List<CarWorkshopDto>();

            var mediatorMock = new Mock<IMediator>();
            mediatorMock.Setup(m => m.Send(It.IsAny<GetAllCarWorkshopsQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(carWorkshops);

            var client = factory
                .WithWebHostBuilder(builder =>
                    builder.ConfigureTestServices(services => services.AddScoped(_ => mediatorMock.Object)))
                .CreateClient();

            // act
            var response = await client.GetAsync("/CarWorkshop/Index");

            // assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var content = await response.Content.ReadAsStringAsync();

            // when no CarWorksop exist there will be no list rendered
            content.Should().NotContain("div class=\"card m-3\"");

        }
    }
}