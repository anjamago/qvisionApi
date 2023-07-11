using FluentValidation;

namespace Application.Editoriales.Command.Update;

public class UpdateEditorialCommandValidate:AbstractValidator<UpdateEditorialCommand>
{
    public UpdateEditorialCommandValidate()
    {
        RuleFor(f => f.Id).NotNull().NotEmpty().DependentRules(() =>
        {
            RuleFor(f => f.name).NotNull().WithName("El nombre dela Editorial es requerido");
            RuleFor(f => f.sede).NotNull().WithName("Campo de sede no puede estar vacio");
        });
    }
}