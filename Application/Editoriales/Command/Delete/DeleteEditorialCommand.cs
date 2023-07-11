using MediatR;

namespace Application.Editoriales.Command.Update;

public record DeleteEditorialCommand(int id) : IRequest;
