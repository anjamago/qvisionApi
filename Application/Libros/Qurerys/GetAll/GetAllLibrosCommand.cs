using Domain.Dtos;
using MediatR;

namespace Application.Libros.GetAll;

public class GetAllLibrosCommand : IRequest<List<LibrosDto>>
{
}