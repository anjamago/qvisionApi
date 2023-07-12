using Application.Autores.Create;
using AutoMapper;
using Moq;
using Persistence.Bases;


namespace QvisionTest.Core.Application.Autores
{
    [TestFixture]
    public class CommnadCreateAutorTest
    {
        private  Mock<IMapper> _mapperMock;
        private  Mock<IBaseRepository<Domain.Entitis.Autores>> _repositoriesMock;
        private CreateCommandHanble _handler;
        
        
        [SetUp]
        public void SetUp()
        {
            _repositoriesMock = new Mock<IBaseRepository<Domain.Entitis.Autores>>();
            _mapperMock = new Mock<IMapper>();
            _handler = new CreateCommandHanble(_repositoriesMock.Object, _mapperMock.Object);
        }

        [Test]
        public async Task Handle_ValidRequest_AddsAuthorToRepository()
        {
            // Arrange
            var request = new CreateAutorCommand("name", "lastname");
 
            var mappedModel = new Domain.Entitis.Autores();
            _mapperMock.Setup(m => m.Map<Domain.Entitis.Autores>(request)).Returns(mappedModel);

            // Act
            await _handler.Handle(request, CancellationToken.None);

            // Assert
            _repositoriesMock.Verify(r => r.AddAsync(mappedModel), Times.Once);

        }
        
        [Test]
        public void Handle_InvalidRequest_ThrowsException()
        {
            // Arrange
            var request = new CreateAutorCommand("name", "lastname");

            _mapperMock.Setup(m => m.Map<Domain.Entitis.Autores>(request)).Throws<AutoMapperMappingException>();

            // Act & Assert
            Assert.ThrowsAsync<AutoMapperMappingException>(async () => await _handler.Handle(request, CancellationToken.None));
        }

    }
}
