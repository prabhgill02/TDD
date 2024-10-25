using Xunit;
using Microsoft.AspNetCore.Mvc;
using FluentAssertions;
using CloudCustomers.WebAPI.Controllers;
using System.Threading.Tasks;
namespace CloudCustomers.UnitTests.Systems.Controllers;

[ApiController]
[Route("[controller]")]
public class TestUsersController
{
    [Fact]
    public async Task Get_OnSuccess_ReturnsStatusCode200()
    {
        // Arrange

        var sut  = new UsersController();


        // Act
        var result = (OkObjectResult)await sut.Get();


        // Assert
        result.StatusCode.Should().Be(200);

    }
}