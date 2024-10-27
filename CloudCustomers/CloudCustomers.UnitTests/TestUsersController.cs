using Xunit;
using Microsoft.AspNetCore.Mvc;
using FluentAssertions;
using CloudCustomers.WebAPI.Controllers;
using CloudCustomers.WebAPI.Models;
using System.Threading.Tasks;
using Moq;
using CloudCustomers.UnitTests.Fixtures;
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
            .ReturnsAsync(new List<User>()
            {
                new() {
                    Id = 1,
                    Name = "Jameson",
                    Address = new Address { 
                        Street = "1232 Main Road",
                        City = "Amritsar",
                        ZipCode = "143001"                   
                    },
                    Email = "abc@gmail.com"
                }
            });
        //    .ReturnsAsync(new List<User>());
              


        // Act
        // As we are now returning NotFoundResult, So we have to changes this as well
        // var result = (OkObjectResult)await sut.Get();

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

    [Fact]
    public async Task Get_OnSuccess_ReturnListOfUser() {
        // Arrange

        var mockUsersService = new Mock<IUsersService>();
        mockUsersService
            .Setup(service => service.GetAllUsers())
            .ReturnsAsync(Fixtures.UsersFixuture.GetTestUsers());

        var sut = new UsersController(mockUsersService.Object);

        // Act
        var  result = await sut.Get();

        // Assert
        result.Should().BeOfType<OkObjectResult>();
  

        var objectResult = (OkObjectResult)result;
        objectResult.Value.Should().BeOfType<List<User>>();

    }

    [Fact]
    public async Task Get_OnNoUserFound_Return404() {
        // Arrange

        var mockUsersService = new Mock<IUsersService>();
        mockUsersService
            .Setup(service => service.GetAllUsers())
            .ReturnsAsync(new List<User>());

        var sut = new UsersController(mockUsersService.Object);

        // Act
        var  result = await sut.Get();

        // Assert

        // We have to change this as well as now we are returning NoObject resutl
        // result.Should().BeOfType<OkObjectResult>();
        // We have to remove this because we will not get OkObjectResult
        // as we have done changes and we are now return Object Not found
        // similarly we have to do the changes in arrange method
        // bcs our expectation from the service is changed now.
        result.Should().BeOfType<NotFoundResult>();
        // var objectResult = (OkObjectResult)result;

        var objectResult = (NotFoundResult)result;

        // objectResult.Value.Should().BeOfType<NotFoundResult>(); 

        objectResult.StatusCode.Should().Be(404);



    }    



}

