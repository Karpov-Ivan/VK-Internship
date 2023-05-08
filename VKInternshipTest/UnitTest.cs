using Moq;
using DBCore;
using Project;
using DTOModels;
using ProjectModels;
using DBCore.Converters;
using VKInternship.Controllers;
using DBModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Xunit;

namespace VKInternshipTest;

public class UnitTest
{
    [Fact]
    public async void TestGetUserByIdAsync()
    {
        //Arrange
        var userId = 1;
        var mock = new Mock<IUserRepository>();
        var controller = new UserController(mock.Object);

        //Act
        var response = await controller.GetUserByIdAsync(userId);

        //Assert
        var result = Assert.IsType<OkObjectResult>(response);
        Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
    }

    [Fact]
    public async void TestGetUserByIdAsyncIdLessThanZero()
    {
        //Arrange
        var userId = -1;
        var mock = new Mock<IUserRepository>();
        var controller = new UserController(mock.Object);

        //Act
        var response = await controller.GetUserByIdAsync(userId);

        //Assert
        var result = Assert.IsType<StatusCodeResult>(response);
        Assert.Equal(StatusCodes.Status400BadRequest, result.StatusCode);
    }

    [Fact]
    public async void TestGetMultipleUserAsync()
    {
        //Arrange
        var skip = 1;
        var count = 2;
        var mock = new Mock<IUserRepository>();
        var controller = new UserController(mock.Object);

        //Act
        var response = await controller.GetMultipleUserAsync(skip, count);

        //Assert
        var result = Assert.IsType<StatusCodeResult>(response);
        Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
    }

    [Fact]
    public async void TestGetMultipleUserAsyncSkipLessThanZero()
    {
        //Arrange
        var skip = -1;
        var count = 2;
        var mock = new Mock<IUserRepository>();
        var controller = new UserController(mock.Object);

        //Act
        var response = await controller.GetMultipleUserAsync(skip, count);

        //Assert
        var result = Assert.IsType<StatusCodeResult>(response);
        Assert.Equal(StatusCodes.Status400BadRequest, result.StatusCode);
    }

    [Fact]
    public async void TestGetMultipleUserAsyncCountLessThanZero()
    {
        //Arrange
        var skip = 1;
        var count = -1;
        var mock = new Mock<IUserRepository>();
        var controller = new UserController(mock.Object);

        //Act
        var response = await controller.GetMultipleUserAsync(skip, count);

        //Assert
        var result = Assert.IsType<StatusCodeResult>(response);
        Assert.Equal(StatusCodes.Status400BadRequest, result.StatusCode);
    }

    [Fact]
    public async void TestGetUserAsync()
    {
        //Arrange
        var mock = new Mock<IUserRepository>();
        var controller = new UserController(mock.Object);

        //Act
        var response = await controller.GetAllUserAsync();

        //Assert
        var result = Assert.IsType<StatusCodeResult>(response);
        Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
    }

    [Fact]
    public async void DeleteUserByIdAsync()
    {
        //Arrange
        long userId = 2;
        var mock = new Mock<IUserRepository>();
        var controller = new UserController(mock.Object);

        //Act
        var response = await controller.DeleteUserByIdAsync(userId);

        //Assert
        var result = Assert.IsType<OkResult>(response);
        Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
    }

    [Fact]
    public async void DeleteUserByIdAsyncIdLessThanZero()
    {
        //Arrange
        long userId = -1;
        var mock = new Mock<IUserRepository>();
        var controller = new UserController(mock.Object);

        //Act
        var response = await controller.DeleteUserByIdAsync(userId);

        //Assert
        var result = Assert.IsType<StatusCodeResult>(response);
        Assert.Equal(StatusCodes.Status400BadRequest, result.StatusCode);
    }

    [Fact]
    public async void DeleteUserByModelAsync()
    {
        //Arrange
        var userDto = new UserDto()
        {
            Login = "anton",
            Password = "qwerty",
            User_Group_Id = 4
        };
        var mock = new Mock<IUserRepository>();
        var controller = new UserController(mock.Object);

        //Act
        var response = await controller.DeleteUserByModelAsync(userDto);

        //Assert
        var result = Assert.IsType<OkResult>(response);
        Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
    }

    [Fact]
    public async void AddUserAsync()
    {
        //Arrange
        var userDto = new UserDto()
        {
            Login = "pavel",
            Password = "qwerty",
            User_Group_Id = 4
        };
        var mock = new Mock<IUserRepository>();
        var controller = new UserController(mock.Object);

        //Act
        var response = await controller.AddUserAsync(userDto);

        //Assert
        var result = Assert.IsType<OkResult>(response);
        Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
    }

    [Fact]
    public async void AddUserAsyncEmptyLogin()
    {
        //Arrange
        var userDto = new UserDto()
        {
            Login = "",
            Password = "qwerty",
            User_Group_Id = 4
        };
        var mock = new Mock<IUserRepository>();
        var controller = new UserController(mock.Object);

        //Act
        var response = await controller.AddUserAsync(userDto);

        //Assert
        var result = Assert.IsType<StatusCodeResult>(response);
        Assert.Equal(StatusCodes.Status400BadRequest, result.StatusCode);
    }

    [Fact]
    public async void AddUserAsyncEmptyPassword()
    {
        //Arrange
        var userDto = new UserDto()
        {
            Login = "pavel",
            Password = "",
            User_Group_Id = 4
        };
        var mock = new Mock<IUserRepository>();
        var controller = new UserController(mock.Object);

        //Act
        var response = await controller.AddUserAsync(userDto);

        //Assert
        var result = Assert.IsType<StatusCodeResult>(response);
        Assert.Equal(StatusCodes.Status400BadRequest, result.StatusCode);
    }

    [Fact]
    public async void AddUserAsyncUserGroupIdLessThanZero()
    {
        //Arrange
        var userDto = new UserDto()
        {
            Login = "pavel",
            Password = "qwerty",
            User_Group_Id = -1
        };
        var mock = new Mock<IUserRepository>();
        var controller = new UserController(mock.Object);

        //Act
        var response = await controller.AddUserAsync(userDto);

        //Assert
        var result = Assert.IsType<StatusCodeResult>(response);
        Assert.Equal(StatusCodes.Status400BadRequest, result.StatusCode);
    }

    [Fact]
    public async void AddUserAsyncUserDtoNull()
    {
        //Arrange
        UserDto userDto = null;
        var mock = new Mock<IUserRepository>();
        var controller = new UserController(mock.Object);

        //Act
        var response = await controller.AddUserAsync(userDto);

        //Assert
        var result = Assert.IsType<StatusCodeResult>(response);
        Assert.Equal(StatusCodes.Status400BadRequest, result.StatusCode);
    }
}