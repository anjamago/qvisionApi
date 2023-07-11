
using Application.Libros.Command.Update;
using FluentValidation;

namespace Application.Libros.Command.Delete;

public class DeleteCommandValidate:AbstractValidator<DeleteLibrosCommand>
{
    
    public DeleteCommandValidate()
    {
        RuleFor(f => f.id).NotNull().NotEmpty().WithMessage("Se requiere un Id para Eliminacion del recurso");
    }
    
    
}
