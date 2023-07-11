using Application.Autores.Command.Update;
using Application.Autores.Create;
using Domain.Dtos;
using Domain.Dtos.Request;

namespace Application.Autores;

public interface IAutorBusiness
{
    Task<RequestBase<object>> Create(CreateAutorCommand request);
    Task<RequestBase<object>> Update(UpdateAutorCommand request);
    Task<RequestBase<object>> Delete(DeleteAutorCommand request);
    Task<RequestBase<AutoresDto>> Find(int request);
    Task<RequestBase<List<AutoresDto>>> All();
}

