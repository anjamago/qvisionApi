using FluentValidation;
using Persistence.Bases;
using Application.Extensions;
namespace Application.Editoriales.Create;


public class CreateCommandValidate:AbstractValidator<CreateEditorialCommand>
{
    private readonly IBaseRepository<Domain.Entitis.Editoriales> _repository;
    public  CreateCommandValidate ( IBaseRepository<Domain.Entitis.Editoriales> repository)
    {
        _repository = repository;
        RuleSet("EditoriaExist",
        ()=>
        {
            RuleFor(r => r.name).MustAsync(AutorExistAsync)
                .WithMessage($" La editorial ya se en cuentra registrada");
        });
        RuleFor(r => r.name).NotEmpty().NotEmpty().WithMessage("Campo Nombre Es requerido no puede ser nulo o vacio");
        RuleFor(r => r.sede).NotEmpty().NotEmpty().WithMessage("Campo Sede es requerido no puede ser nulo o vacio");
    }

    private async Task<bool> AutorExistAsync(string name, CancellationToken cancellationToken)
    {
        var isValid = await _repository.GetAsync(
            predicate: ed => ed.Nombre == name
        );
       return !isValid.IsValid();
    }
}