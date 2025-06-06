using AnnouncementService.BLL.Users.Commands;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Moq;

public class RegisterCommandHandlerTests
{
    private readonly Mock<UserManager<IdentityUser>> _userManagerMock;

    public RegisterCommandHandlerTests()
    {
        var store = new Mock<IUserStore<IdentityUser>>();
        _userManagerMock = new Mock<UserManager<IdentityUser>>(
            store.Object, null, null, null, null, null, null, null, null);
    }

    [Fact]
    public async Task Handle_ShouldCreateUser_WhenDataIsValid()
    {
        // Arrange
        var command = new RegisterCommand(userName: "testuser", email: "test@example.com", password: "P@ssw0rd");

        _userManagerMock
            .Setup(um => um.CreateAsync(It.IsAny<IdentityUser>(), command.Password))
            .ReturnsAsync(IdentityResult.Success);

        var handler = new RegisterCommandHandler(_userManagerMock.Object);

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.Equal(Unit.Value, result);
        _userManagerMock.Verify(um => um.CreateAsync(
            It.Is<IdentityUser>(u => u.UserName == command.UserName && u.Email == command.Email),
            command.Password), Times.Once);
    }

    [Fact]
    public async Task Handle_ShouldThrowException_WhenCreationFails()
    {
        // Arrange
        var command = new RegisterCommand(userName: "testuser", email: "test@example.com", password: "P@ssw0rd");

        var identityError = new IdentityError { Description = "Error creating user" };

        _userManagerMock
            .Setup(um => um.CreateAsync(It.IsAny<IdentityUser>(), command.Password))
            .ReturnsAsync(IdentityResult.Failed(identityError));

        var handler = new RegisterCommandHandler(_userManagerMock.Object);

        // Act & Assert
        var ex = await Assert.ThrowsAsync<Exception>(() =>
            handler.Handle(command, CancellationToken.None));

        Assert.Contains("Error creating user", ex.Message);
    }
}
