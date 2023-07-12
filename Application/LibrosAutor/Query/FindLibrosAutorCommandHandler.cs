using Domain.Dtos;
using Domain.Entitis;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Bases;
using System.Linq.Expressions;

namespace Application.LibrosAutor.Query;

public class FindLibrosAutorCommandHandler : IRequestHandler<FindLibrosAutorCommand, LibrosAutorDto>
{
    private readonly IBaseRepository<AutoresHasLibros> _repository;

    public FindLibrosAutorCommandHandler(IBaseRepository<AutoresHasLibros> repository)
    {
        _repository = repository;
    }

    public async Task<LibrosAutorDto> Handle(FindLibrosAutorCommand request, CancellationToken cancellationToken)
    {
        Expression<Func<AutoresHasLibros, bool>> func = p =>
            (request.idAutor > 0) ? p.autorId.Equals(request.idAutor) : p.libro_ISBN.Equals(request.idLibro);
        var model = await _repository.GetAsync(
            predicate: func,
            include: inc => inc.Include(i => i.Autores)
        );

        return new LibrosAutorDto()
        {
            Libros = model.Libros,
            Autores = model.Autores
        };
    }
}