using Application.Libros.Command.Update;
using Application.Libros.Create;
using Domain.Dtos;
using Domain.Dtos.Request;

namespace Application.Libros;

public interface ILibrosBusiness
{
    Task<RequestBase<object>> Create(CreateLibrosCommand request);
    Task<RequestBase<object> >Update(UpdateLibrosCommand request);
    Task<RequestBase<object> >Delete(DeleteLibrosCommand request);
    Task<RequestBase<LibrosDto> >Find( int id);
    Task<RequestBase<List<LibrosDto>> >All();
}