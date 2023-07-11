using MediatR;

namespace Application.Editoriales.Create;

public record CreateEditorialCommand(string name, string sede) : IRequest;
