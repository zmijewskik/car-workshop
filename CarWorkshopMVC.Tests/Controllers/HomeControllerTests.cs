using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using Xunit;

namespace CarWorkshopMVC.Controllers.Tests
{
    public class HomeControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> factory;

        public HomeControllerTests(WebApplicationFactory<Program> factory)
        {
            this.factory = factory;
        }

        [Fact()]
        public async Task About_ReturnsViewWithRenderModel()
        {
            // arrange
            var client = factory.CreateClient();

            // act
            var response = await client.GetAsync("/Home/About");

            // assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            // content will be full HTML from /Home/About
            var content = await response.Content.ReadAsStringAsync();

            content.Should().Contain("<h1>CarWorkshop app</h1>")
                .And.Contain("<div class=\"alert alert-primary\">Website based on a car workshops.</div>")
                .And.Contain("<li>car</li>")
                .And.Contain("<li>app</li>")
                .And.Contain("<li>free</li>");

        }
    }
}