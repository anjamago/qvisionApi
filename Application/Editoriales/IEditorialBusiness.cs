using Application.Editoriales.Command.Update;
using Application.Editoriales.Create;
using Domain.Dtos;
using Domain.Dtos.Request;

namespace Application.Editoriales;

public interface IEditorialBusiness
{
    Task<RequestBase<object>> Create(CreateEditorialCommand request);
    Task<RequestBase<object> >Update(UpdateEditorialCommand request);
    Task<RequestBase<object> >Delete(DeleteEditorialCommand request);
    Task<RequestBase<EditorialDto> >Find( int id);
    Task<RequestBase<EditorialDto> >All();
}