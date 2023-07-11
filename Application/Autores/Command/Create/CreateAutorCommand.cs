using MediatR;

namespace Application.Autores.Create;

public record CreateAutorCommand(string name, string lastName) : IRequest;
