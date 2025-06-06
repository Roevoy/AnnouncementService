using AnnouncementService.BLL.Сommands;
using AnnouncementService.DAL.Interfaces;
using MediatR;
using Moq;

public class DeleteAnnouncementCommandHandlerTests
{
    private readonly Mock<IAnnouncementRepository> _repoMock;

    public DeleteAnnouncementCommandHandlerTests()
    {
        _repoMock = new Mock<IAnnouncementRepository>();
    }

    [Fact]
    public async Task Handle_ShouldDeleteAnnouncement_WhenIdIsValid()
    {
        // Arrange
        var command = new DeleteAnnouncementCommand { Id = Guid.NewGuid() };

        _repoMock.Setup(r => r.DeleteAnnouncementAsync(command.Id))
                 .Returns(Task.CompletedTask)
                 .Verifiable();

        var handler = new DeleteAnnouncementCommandHandler(_repoMock.Object);

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.Equal(Unit.Value, result);
        _repoMock.Verify(r => r.DeleteAnnouncementAsync(command.Id), Times.Once);
    }
}
