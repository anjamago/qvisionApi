using MediatR;

namespace Application.Autores.Command.Update;

public record DeleteAutorCommand(int id) : IRequest;
