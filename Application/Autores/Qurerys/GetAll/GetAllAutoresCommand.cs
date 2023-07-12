using Domain.Dtos;
using MediatR;

namespace Application.Autores.GetAll;

public class GetAllAutoresCommand : IRequest<List<AutoresDto>>
{
}