using Domain.Dtos;
using MediatR;

namespace Application.LibrosAutor.Query;

public record FindLibrosAutorCommand(int? idAutor, int? idLibro) : IRequest<LibrosAutorDto>;
