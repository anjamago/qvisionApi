using MediatR;

namespace Application.Autores.Command.Update;

public record UpdateAutorCommand(int Id, string name, string lastName) : IRequest;

