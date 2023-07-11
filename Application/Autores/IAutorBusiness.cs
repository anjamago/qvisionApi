using Application.Autores.Create;
using Domain.Dtos;
using Domain.Dtos.Request;

namespace Application.Autores;

public interface IAutorBusiness
{
    Task<RequestBase<object>> Create(CreateAutorCommand request);
    Task<RequestBase<object>> Update(CreateAutorCommand request);
    Task<RequestBase<object>> Delete(CreateAutorCommand request);
    Task<RequestBase<AutoresDto>> Find(CreateAutorCommand request);
    Task<RequestBase<List<AutoresDto>>> All();
}

