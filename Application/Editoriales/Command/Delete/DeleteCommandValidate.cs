
using Application.Editoriales.Command.Update;
using FluentValidation;

namespace Application.Editoriales.Command.Delete;

public class DeleteCommandValidate:AbstractValidator<DeleteEditorialCommand>
{
    
    public DeleteCommandValidate()
    {
        RuleFor(f => f.id).NotNull().NotEmpty().WithMessage("Se requiere un Id para Eliminacion del recurso");
    }
    
    
}
