using AnnouncementService.BLL.Сommands;
using AnnouncementService.Core.Models;
using AnnouncementService.DAL.Interfaces;
using MediatR;
using Moq;

public class UpdateAnnouncementCommandHandlerTests
{
    private readonly Mock<IAnnouncementRepository> _repoMock;

    public UpdateAnnouncementCommandHandlerTests()
    {
        _repoMock = new Mock<IAnnouncementRepository>();
    }

    [Fact]
    public async Task Handle_ShouldUpdateTitleAndDescription_WhenBothProvided()
    {
        // Arrange
        var id = Guid.NewGuid();
        var existing = new Announcement
        {
            Id = id,
            Title = "Old Title",
            Description = "Old Desc",
            DateAdded = DateTime.UtcNow.AddDays(-1),
            DateUpdated = null
        };

        var command = new UpdateAnnouncementCommand(id, "New Title", "New Desc");

        _repoMock.Setup(r => r.GetAnnouncementByIdAsync(id)).ReturnsAsync(existing);
        _repoMock.Setup(r => r.UpdateAnnouncementAsync(It.IsAny<Announcement>())).Returns(Task.CompletedTask).Verifiable();

        var handler = new UpdateAnnouncementCommandHandler(_repoMock.Object);

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.Equal("New Title", existing.Title);
        Assert.Equal("New Desc", existing.Description);
        Assert.NotNull(existing.DateUpdated);
        _repoMock.Verify(r => r.UpdateAnnouncementAsync(existing), Times.Once);
        Assert.Equal(Unit.Value, result);
    }

    [Fact]
    public async Task Handle_ShouldUpdateOnlyTitle_WhenOnlyTitleProvided()
    {
        // Arrange
        var id = Guid.NewGuid();
        var existing = new Announcement
        {
            Id = id,
            Title = "Old Title",
            Description = "Old Desc"
        };

        var command = new UpdateAnnouncementCommand(id, "Only New Title")
        {
            NewDescription = null
        };

        _repoMock.Setup(r => r.GetAnnouncementByIdAsync(id)).ReturnsAsync(existing);
        _repoMock.Setup(r => r.UpdateAnnouncementAsync(It.IsAny<Announcement>())).Returns(Task.CompletedTask).Verifiable();

        var handler = new UpdateAnnouncementCommandHandler(_repoMock.Object);

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.Equal("Only New Title", existing.Title);
        Assert.Equal("Old Desc", existing.Description);
        Assert.NotNull(existing.DateUpdated);
        _repoMock.Verify(r => r.UpdateAnnouncementAsync(existing), Times.Once);
        Assert.Equal(Unit.Value, result);
    }
}

