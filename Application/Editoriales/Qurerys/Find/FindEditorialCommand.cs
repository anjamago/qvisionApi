using Domain.Dtos;
using MediatR;

namespace Application.Editoriales.Qurerys.Find;

public record FindEditorialCommand(int id) : IRequest<EditorialDto>;
