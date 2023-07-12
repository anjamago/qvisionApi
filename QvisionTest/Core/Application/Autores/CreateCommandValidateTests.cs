using Application.Autores.Create;
using FluentValidation.TestHelper;
using Microsoft.EntityFrameworkCore.Query;
using Moq;
using Persistence.Bases;
using System.Linq.Expressions;

namespace QvisionTest.Core.Application.Autores
{

    [TestFixture]
    public class CreateCommandValidateTests
    {
        private CreateCommandValidate _validator;
        private Mock<IBaseRepository<Domain.Entitis.Autores>> _repositoryMock;

        [SetUp]
        public void SetUp()
        {
            _repositoryMock = new Mock<IBaseRepository<Domain.Entitis.Autores>>();
            _validator = new CreateCommandValidate(_repositoryMock.Object);
        }

        [Test]
        public async Task Validate_UniqueName_ReturnsTrue()
        {
            // Arrange
            var command = new CreateAutorCommand("name", "lastname");
            _repositoryMock.Setup(r => r.GetAsync(
                It.IsAny<Expression<Func<Domain.Entitis.Autores, bool>>>(),
                null,
                null,
                null))
                .ReturnsAsync((Expression<Func<Domain.Entitis.Autores, bool>> predicate,
                    Func<IQueryable<Domain.Entitis.Autores>, IIncludableQueryable<Domain.Entitis.Autores, object>> include,
                    Func<IQueryable<Domain.Entitis.Autores>, IOrderedQueryable<Domain.Entitis.Autores>> orderBy,
                    Expression<Func<Domain.Entitis.Autores, Domain.Entitis.Autores>> selector) => null);

            // Act
            var result = await _validator.TestValidateAsync(command, op => op.IncludeRuleSets("NameExist"));

            // Assert
            result.ShouldNotHaveValidationErrorFor(c => c.name);
        }

        [Test]
        public async Task Validate_DuplicateName_ReturnsError()
        {
            // Arrange
            var command = new CreateAutorCommand("name", "lastname");
            _repositoryMock.Setup(r => r.GetAsync(
                It.IsAny<Expression<Func<Domain.Entitis.Autores, bool>>>(),
                null,
                null,
                null))
                .ReturnsAsync((Expression<Func<Domain.Entitis.Autores, bool>> predicate,
                    Func<IQueryable<Domain.Entitis.Autores>, IIncludableQueryable<Domain.Entitis.Autores, object>> include,
                    Func<IQueryable<Domain.Entitis.Autores>, IOrderedQueryable<Domain.Entitis.Autores>> orderBy,
                    Expression<Func<Domain.Entitis.Autores, Domain.Entitis.Autores>> selector) => new Domain.Entitis.Autores());

            // Act
            var result = await _validator.TestValidateAsync(command, op => op.IncludeRuleSets("NameExist"));

            // Assert

            result.ShouldHaveValidationErrorFor(p => p.name)
                .WithErrorMessage("Nombre de autor ya se encuetra registrado en el sistema name")
               ;


        }

        [Test]
        public void Validate_EmptyName_ReturnsError()
        {
            // Arrange
            var command = new CreateAutorCommand("", "lastname");

            // Act
            var result = _validator.TestValidate(command);

            // Assert
            result.ShouldHaveValidationErrorFor(c => c.name)
                .WithErrorMessage("'name' no debería estar vacío.");
        }

        [Test]
        public void Validate_EmptyLastName_ReturnsError()
        {
            // Arrange
            var command = new CreateAutorCommand("name", "");

            // Act
            var result = _validator.TestValidate(command);

            // Assert
            result.ShouldHaveValidationErrorFor(c => c.lastName)
                .WithErrorMessage("'last Name' no debería estar vacío.");
        }
    }

}
