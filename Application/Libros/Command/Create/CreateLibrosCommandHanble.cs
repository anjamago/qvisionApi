using AutoMapper;
using Domain.Entitis;
using MediatR;
using Persistence.Bases;

namespace Application.Libros.Create;

internal class CreateLibrosCommandHanble : IRequestHandler<CreateLibrosCommand>
{
    private readonly IBaseRepository<Domain.Entitis.Libros> _repository;
    private readonly IBaseRepository<Domain.Entitis.AutoresHasLibros> _repositoryahl;
    private readonly IMapper _mapper;

    public CreateLibrosCommandHanble(IBaseRepository<Domain.Entitis.Libros> repository, IMapper mapper, IBaseRepository<AutoresHasLibros> repositoryahl)
    {
        _repository = repository;
        _mapper = mapper;
        _repositoryahl = repositoryahl;
    }

    public async Task Handle(CreateLibrosCommand request, CancellationToken cancellationToken)
    {

        var model = _mapper.Map<Domain.Entitis.Libros>(request);
        await _repository.AddAsync(model);
        var libro = await _repository.GetAsync(predicate: p => p.titulo == model.titulo);

        var hasLibroAutor = new AutoresHasLibros()
        {
            autorId = request.AutorId,
            libro_ISBN = libro.ISBN
        };

        await _repositoryahl.AddAsync(hasLibroAutor);

    }
}