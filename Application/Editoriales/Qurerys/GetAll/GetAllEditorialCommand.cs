using Domain.Dtos;
using MediatR;

namespace Application.Editoriales.GetAll;

public class GetAllEditorialCommand:IRequest<List<EditorialDto>>
{
}