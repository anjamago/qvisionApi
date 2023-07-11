using MediatR;

namespace Application.Libros.Command.Update;

public record DeleteLibrosCommand(int id) : IRequest;
