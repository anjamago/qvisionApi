using MediatR;

namespace Application.Editoriales.Command.Update;

public record UpdateEditorialCommand(int Id, string name, string sede) : IRequest;

