using Xunit;
using Microsoft.AspNetCore.Mvc;
using FluentAssertions;
using CloudCustomers.WebAPI.Controllers;
using CloudCustomers.WebAPI.Models;
using System.Threading.Tasks;
using Moq;
namespace CloudCustomers.UnitTests.Systems.Controllers;

[ApiController]
[Route("[controller]")]
public class TestUsersController
{
    [Fact]
    public async Task Get_OnSuccess_ReturnsStatusCode200()
    {
        // Arrange
        var mockUsersService = new Mock<IUsersService>();
        var sut  = new UsersController(mockUsersService.Object);
        mockUsersService
            .Setup(service => service.GetAllUsers())
            .ReturnsAsync(new List<User>());     

        // Act
        var result = (OkObjectResult)await sut.Get();
        
        // Assert
        result.StatusCode.Should().Be(200);

    }

    [Fact]
    public async Task Get_OnSuccess_InvokeUserService() {
        // Arrange
        var mockUsersService = new Mock<IUsersService>();
        mockUsersService
            .Setup(service => service.GetAllUsers())
            .ReturnsAsync(new List<User>());
        var sut = new UsersController(mockUsersService.Object);

        // Act
        var result = await sut.Get();

        // Assert

        mockUsersService.Verify(service => service.GetAllUsers(), Times.Once());
    }
}