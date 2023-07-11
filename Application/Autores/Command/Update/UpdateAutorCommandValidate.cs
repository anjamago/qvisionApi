using FluentValidation;

namespace Application.Autores.Command.Update;

public class UpdateAutorCommandValidate:AbstractValidator<UpdateAutorCommand>
{
    public UpdateAutorCommandValidate()
    {
        RuleFor(f => f.Id).NotNull().NotEmpty().DependentRules(() =>
        {
            RuleFor(f => f.name).NotNull().WithName("El nombre del autor es requerido");
            RuleFor(f => f.lastName).NotNull().WithName("El Appellido del autori no puede estar vacio");
        });
    }
}