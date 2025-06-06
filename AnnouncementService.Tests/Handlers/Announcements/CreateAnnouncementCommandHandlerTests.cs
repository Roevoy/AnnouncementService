using AnnouncementService.BLL.Сommands;
using AnnouncementService.Core.Models;
using AnnouncementService.DAL.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Moq;

public class CreateAnnouncementCommandHandlerTests
{
    private readonly Mock<IAnnouncementRepository> _repoMock;
    private readonly Mock<UserManager<IdentityUser>> _userManagerMock;

    public CreateAnnouncementCommandHandlerTests()
    {
        _repoMock = new Mock<IAnnouncementRepository>();

        var store = new Mock<IUserStore<IdentityUser>>();
        _userManagerMock = new Mock<UserManager<IdentityUser>>(
            store.Object, null, null, null, null, null, null, null, null);
    }

    [Fact]
    public async Task Handle_ShouldCreateAnnouncement_WhenValidRequest()
    {
        // Arrange
        var command = new CreateAnnouncementCommand("Test Title", "Test Description")
        {
            CreatorId = "user123"
        };

        _repoMock.Setup(r => r.CreateAnnouncementAsync(It.IsAny<Announcement>()))
                 .Returns(Task.CompletedTask)
                 .Verifiable();

        var handler = new CreateAnnouncementCommandHandler(_repoMock.Object, _userManagerMock.Object);

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.Equal(Unit.Value, result);

        _repoMock.Verify(r => r.CreateAnnouncementAsync(It.Is<Announcement>(a =>
            a.CreatorId == command.CreatorId &&
            a.Title == command.Title &&
            a.Description == command.Description &&
            a.DateAdded != default &&
            a.DateUpdated == null
        )), Times.Once);
    }
}

