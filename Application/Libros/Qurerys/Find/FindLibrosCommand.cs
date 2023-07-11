using Domain.Dtos;
using MediatR;

namespace Application.Libros.Qurerys.Find;

public record FindLibrosCommand(int id) : IRequest<LibrosDto>;
