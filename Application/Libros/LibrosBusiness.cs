using System.Net;
using Application.Extensions;
using Application.Libros.Command.Update;
using Application.Libros.Create;
using Application.Libros.GetAll;
using Application.Libros.Qurerys.Find;
using Domain.Dtos;
using Domain.Dtos.Request;
using FluentValidation;
using MediatR;

namespace Application.Libros;

public class LibrosBusiness : ILibrosBusiness
{
    
    private readonly ISender _sender;
    private readonly IValidator<DeleteLibrosCommand> _delete;
    private readonly IValidator<UpdateLibrosCommand> _update;
    private readonly IValidator<CreateLibrosCommand> _create;

    public LibrosBusiness(ISender sender, IValidator<DeleteLibrosCommand> delete, IValidator<UpdateLibrosCommand> update, IValidator<CreateLibrosCommand> create)
    {
        _sender = sender;
        _delete = delete;
        _update = update;
        _create = create;
    }

    public async Task<RequestBase<object>> Create(CreateLibrosCommand request)
    {
        var result = await _create.ValidateAsync(request);

        if (!result.IsValid)
        {
            return new RequestBase<object>(code: HttpStatusCode.BadRequest, message:"Errors" , errors: result.ResultErrors());
        }

        await _sender.Send(request);

        return new RequestBase<object>();

    }

    public async Task<RequestBase<object> >Update(UpdateLibrosCommand request)
    {
        var result = await _update.ValidateAsync(request);

        if (!result.IsValid)
        {
            return new RequestBase<object>(code: HttpStatusCode.BadRequest, message:"Errors" , errors: result.ResultErrors());
        }

        await _sender.Send(request);

        return new RequestBase<object>();
    }
    
    public async Task<RequestBase<object> >Delete(DeleteLibrosCommand request)
    {
        var result = await _delete.ValidateAsync(request);

        if (!result.IsValid)
        {
            return new RequestBase<object>(code: HttpStatusCode.BadRequest, message:"Errors" , errors: result.ResultErrors());
        }

        await _sender.Send(request);

        return new RequestBase<object>();
    }
    
    public async Task<RequestBase<LibrosDto> >Find( int id)
    {
        FindLibrosCommand model = new(id);
        var result = await _sender.Send(model);

        return new RequestBase<LibrosDto>();
    }
    

    public async Task<RequestBase<List<LibrosDto>> >All()
    {
        
        var result = await _sender.Send(new GetAllLibrosCommand());

        return new RequestBase<List<LibrosDto>>();
    }
    
}