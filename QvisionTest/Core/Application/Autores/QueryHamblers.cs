using Application.Autores.GetAll;
using Application.Autores.Qurerys.Find;
using AutoMapper;
using Domain.Dtos;
using Moq;
using Persistence.Bases;
using System.Linq.Expressions;

namespace QvisionTest.Core.Application.Autores
{
    public class QueryHamblers
    {
        private GetAllAutoresCommandHandler _handler;
        private Mock<IBaseRepository<Domain.Entitis.Autores>> _repositoryMock;
        private Mock<IMapper> _mapperMock;
        private FindAutorCommandHandler _handlerFind;




        [SetUp]
        public void SetUp()
        {
            _repositoryMock = new Mock<IBaseRepository<Domain.Entitis.Autores>>();
            _mapperMock = new Mock<IMapper>();
            _handler = new GetAllAutoresCommandHandler(_repositoryMock.Object, _mapperMock.Object);
            _handlerFind = new FindAutorCommandHandler(_repositoryMock.Object, _mapperMock.Object);
        }

        [Test]
        public async Task Handle_ValidRequest_ReturnsMappedResult()
        {
            // Arrange
            var command = new GetAllAutoresCommand();
            var cancellationToken = CancellationToken.None;
            var entities = new List<Domain.Entitis.Autores>
        {
            new Domain.Entitis.Autores { Id = 1, Nombre = "nombre" },
            new Domain.Entitis.Autores { Id = 2, Nombre = "nombre2" }
        };
            var dtoList = new List<AutoresDto>
        {
            new AutoresDto { Id = 1, Nombre = "nombre" },
            new AutoresDto { Id = 2, Nombre = "nombre2" }
        };
            _repositoryMock.Setup(r => r.GetAllAsync(null, null, null, null))
                .ReturnsAsync(entities);
            _mapperMock.Setup(m => m.Map<List<AutoresDto>>(entities))
                .Returns(dtoList);

            // Act
            var result = await _handler.Handle(command, cancellationToken);

            // Assert
            Assert.AreEqual(dtoList, result);
        }

        [Test]
        public void Handle_InvalidRequest_ThrowsException()
        {
            // Arrange
            var command = new GetAllAutoresCommand();
            var cancellationToken = CancellationToken.None;
            _repositoryMock.Setup(r => r.GetAllAsync(null, null, null, null))
                .ThrowsAsync(new Exception("Database connection error"));

            // Act & Assert
            Assert.ThrowsAsync<Exception>(async () => await _handler.Handle(command, cancellationToken));
        }


        [Test]
        public async Task Handle_ValidRequestFind_ReturnsMappedResult()
        {
            // Arrange
            var command = new FindAutorCommand(1);
            var cancellationToken = CancellationToken.None;
            var entity = new Domain.Entitis.Autores() { Id = 1, Nombre = "" };
            var dto = new AutoresDto { Id = 1, Nombre = "" };
            _repositoryMock.Setup(r => r.GetAsync(It.IsAny<Expression<Func<Domain.Entitis.Autores, bool>>>(), null, null, null))
                .ReturnsAsync(entity);
            _mapperMock.Setup(m => m.Map<AutoresDto>(entity))
                .Returns(dto);

            // Act
            var result = await _handlerFind.Handle(command, cancellationToken);

            // Assert
            Assert.AreEqual(dto, result);
        }

        [Test]
        public void Handle_InvalidRequestFind_ThrowsException()
        {
            // Arrange
            var command = new FindAutorCommand(1);
            var cancellationToken = CancellationToken.None;
            _repositoryMock.Setup(r => r.GetAsync(It.IsAny<Expression<Func<Domain.Entitis.Autores, bool>>>(), null, null, null))
                .ThrowsAsync(new Exception("Database connection error"));

            // Act & Assert
            Assert.ThrowsAsync<Exception>(async () => await _handlerFind.Handle(command, cancellationToken));
        }
    }


}
