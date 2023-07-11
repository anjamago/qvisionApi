using System.Net;
using Application.Editoriales.Command.Update;
using Application.Editoriales.Create;
using Application.Editoriales.GetAll;
using Application.Editoriales.Qurerys.Find;
using Application.Extensions;
using Application.Libros.GetAll;
using Domain.Dtos;
using Domain.Dtos.Request;
using FluentValidation;
using MediatR;

namespace Application.Editoriales;

public class EditorialBusiness : IEditorialBusiness
{
    private readonly ISender _sender;
    private readonly IValidator<DeleteEditorialCommand> _delete;
    private readonly IValidator<UpdateEditorialCommand> _update;
    private readonly IValidator<CreateEditorialCommand> _create;

    public EditorialBusiness(ISender sender, IValidator<DeleteEditorialCommand> delete, IValidator<UpdateEditorialCommand> update, IValidator<CreateEditorialCommand> create)
    {
        _sender = sender;
        _delete = delete;
        _update = update;
        _create = create;
    }

    public async Task<RequestBase<object>> Create(CreateEditorialCommand request)
    {
        var result = await _create.ValidateAsync(request);

        if (!result.IsValid)
        {
            return new RequestBase<object>(code: HttpStatusCode.BadRequest, message:"Errors" , errors: result.ResultErrors());
        }

        await _sender.Send(request);

        return new RequestBase<object>();

    }

    public async Task<RequestBase<object> >Update(UpdateEditorialCommand request)
    {
        var result = await _update.ValidateAsync(request);

        if (!result.IsValid)
        {
            return new RequestBase<object>(code: HttpStatusCode.BadRequest, message:"Errors" , errors: result.ResultErrors());
        }

        await _sender.Send(request);

        return new RequestBase<object>();
    }
    
    public async Task<RequestBase<object> >Delete(DeleteEditorialCommand request)
    {
        var result = await _delete.ValidateAsync(request);

        if (!result.IsValid)
        {
            return new RequestBase<object>(code: HttpStatusCode.BadRequest, message:"Errors" , errors: result.ResultErrors());
        }

        await _sender.Send(request);

        return new RequestBase<object>();
    }
    
    public async Task<RequestBase<EditorialDto> >Find( int id)
    {
        FindEditorialCommand model = new(id);
        var result = await _sender.Send(model);

        return new RequestBase<EditorialDto>();
    }
    
    public async Task<RequestBase<EditorialDto> >All()
    {
        
        var result = await _sender.Send(new GetAllEditorialCommand());

        return new RequestBase<EditorialDto>();
    }
}