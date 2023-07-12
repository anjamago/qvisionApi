using FluentValidation;
using Persistence.Bases;
using Application.Extensions;
namespace Application.Autores.Create;


public class CreateCommandValidate:AbstractValidator<CreateAutorCommand>
{
    private readonly IBaseRepository<Domain.Entitis.Autores> _repository;
    public  CreateCommandValidate ( IBaseRepository<Domain.Entitis.Autores> repository)
    {
        _repository = repository;
        RuleSet("NameExist",
        ()=>
        {
            RuleFor(r => r.name).MustAsync(AutorExistAsync)
                .WithMessage("Nombre de autor ya se encuetra registrado en el sistema {PropertyName}");
        });
        RuleFor(r => r.name).NotEmpty().NotEmpty().WithMessage("Campo nombre de autor no puedes ser nulo o vacio {PropertyName}");
        RuleFor(r => r.lastName).NotEmpty().NotEmpty().WithMessage("Campo Apellidos del autor no puedes ser nulo o vacio {PropertyName}");
    }

    private async Task<bool> AutorExistAsync(string name, CancellationToken cancellationToken)
    {
        var isValid = await _repository.GetAsync(
            predicate: aut => aut.Nombre == name
        );
       return !isValid.IsValid();
    }
}