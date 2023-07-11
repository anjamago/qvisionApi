using Domain.Dtos;
using MediatR;

namespace Application.Autores.Qurerys.Find;

public record FindAutorCommand(int id) : IRequest<AutoresDto>;
