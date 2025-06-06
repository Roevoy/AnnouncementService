using Xunit;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using AnnouncementService.BLL.Users.Queries;

public class LoginQueryHandlerTests
{
    private readonly Mock<UserManager<IdentityUser>> _userManagerMock;
    private readonly Mock<IConfiguration> _configurationMock;

    public LoginQueryHandlerTests()
    {
        var store = new Mock<IUserStore<IdentityUser>>();
        _userManagerMock = new Mock<UserManager<IdentityUser>>(
            store.Object, null, null, null, null, null, null, null, null);

        _configurationMock = new Mock<IConfiguration>();
        _configurationMock.Setup(c => c["Jwt:Key"]).Returns("super_secret_test_key_1234567890!!"); 
        _configurationMock.Setup(c => c["Jwt:Issuer"]).Returns("TestIssuer");
    }

    [Fact]
    public async Task Handle_ShouldReturnJwtToken_WhenCredentialsAreValid()
    {
        // Arrange
        var user = new IdentityUser
        {
            Id = "user-id",
            Email = "test@example.com",
            UserName = "testuser"
        };

        var command = new LoginQuery(email: "test@example.com", password: "ValidPassword123");

        _userManagerMock.Setup(um => um.FindByEmailAsync(command.Email))
            .ReturnsAsync(user);

        _userManagerMock.Setup(um => um.CheckPasswordAsync(user, command.Password))
            .ReturnsAsync(true);

        _userManagerMock.Setup(um => um.GetRolesAsync(user))
            .ReturnsAsync(new List<string> { "User" });

        var handler = new LoginQueryHandler(_userManagerMock.Object, _configurationMock.Object);

        // Act
        var token = await handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.False(string.IsNullOrWhiteSpace(token));
        var handlerToken = new JwtSecurityTokenHandler();
        var parsedToken = handlerToken.ReadJwtToken(token);
        Assert.Equal("TestIssuer", parsedToken.Issuer);
    }

    [Fact]
    public async Task Handle_ShouldThrow_WhenUserNotFound()
    {
        // Arrange
        var command = new LoginQuery(password: "Password123", email: "notfound@example.com");

        _userManagerMock.Setup(um => um.FindByEmailAsync(command.Email))
            .ReturnsAsync((IdentityUser)null);

        var handler = new LoginQueryHandler(_userManagerMock.Object, _configurationMock.Object);

        // Act & Assert
        await Assert.ThrowsAsync<UnauthorizedAccessException>(() =>
            handler.Handle(command, CancellationToken.None));
    }

    [Fact]
    public async Task Handle_ShouldThrow_WhenPasswordIsInvalid()
    {
        // Arrange
        var user = new IdentityUser { Email = "test@example.com" };
        var command = new LoginQuery( email: "test@example.com", password: "WrongPassword");

        _userManagerMock.Setup(um => um.FindByEmailAsync(command.Email))
            .ReturnsAsync(user);

        _userManagerMock.Setup(um => um.CheckPasswordAsync(user, command.Password))
            .ReturnsAsync(false);

        var handler = new LoginQueryHandler(_userManagerMock.Object, _configurationMock.Object);

        // Act & Assert
        await Assert.ThrowsAsync<UnauthorizedAccessException>(() =>
            handler.Handle(command, CancellationToken.None));
    }
}
