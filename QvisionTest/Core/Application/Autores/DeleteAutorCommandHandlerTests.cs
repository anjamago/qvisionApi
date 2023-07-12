using Application.Autores.Command.Delete;
using Application.Autores.Command.Update;
using Moq;
using Persistence.Bases;

namespace QvisionTest.Core.Application.Autores
{
    [TestFixture]
    public class DeleteAutorCommandHandlerTests
    {
        private DeleteAutorCommandHandler _handler;
        private Mock<IBaseRepository<Domain.Entitis.Autores>> _repositoryMock;

        [SetUp]
        public void SetUp()
        {
            _repositoryMock = new Mock<IBaseRepository<Domain.Entitis.Autores>>();
            _handler = new DeleteAutorCommandHandler(_repositoryMock.Object);
        }

        [Test]
        public async Task Handle_ValidRequest_DeletesAutorFromRepository()
        {
            // Arrange
            var command = new DeleteAutorCommand(id: 1);
            var cancellationToken = CancellationToken.None;

            // Act
            await _handler.Handle(command, cancellationToken);

            // Assert
            _repositoryMock.Verify(r => r.DeleteAsync(It.IsAny<Domain.Entitis.Autores>(), null), Times.Once);
        }

        [Test]
        public async Task Handle_InvalidRequest_DoesNotDeleteAutorFromRepository()
        {
            // Arrange
            var command = new DeleteAutorCommand(id: 1);
            var cancellationToken = CancellationToken.None;
            var model = new Domain.Entitis.Autores();
            _repositoryMock.Setup(r => r.DeleteAsync(It.IsAny<Domain.Entitis.Autores>(), null))
                .ReturnsAsync(0);

            // Act
            await _handler.Handle(command, cancellationToken);

            // Assert
            _repositoryMock.Verify(r => r.DeleteAsync(It.IsAny<Domain.Entitis.Autores>(), null), Times.Once);
        }
    }
}
