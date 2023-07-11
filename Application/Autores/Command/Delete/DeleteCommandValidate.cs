using Application.Autores.Command.Update;
using FluentValidation;

namespace Application.Autores.Command.Delete;

public class DeleteCommandValidate:AbstractValidator<DeleteAutorCommand>
{
    
    public DeleteCommandValidate()
    {
        RuleFor(f => f.id).NotNull().NotEmpty().WithMessage("Se requiere un Id para Eliminacion del recurso");
    }
    
    
}
