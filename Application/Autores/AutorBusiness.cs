using System.Net;
using Application.Autores.Command.Update;
using Application.Autores.Create;
using Application.Autores.GetAll;
using Application.Autores.Qurerys.Find;
using Application.Extensions;
using Domain.Dtos;
using Domain.Dtos.Request;
using FluentValidation;
using MediatR;

namespace Application.Autores;



public class AutorBusiness : IAutorBusiness
{
    private readonly ISender _sender;
    private readonly IValidator<CreateAutorCommand> _createValidate;
    private readonly IValidator<UpdateAutorCommand> _updateValidate;
    private readonly IValidator<DeleteAutorCommand> _deleteValidate;

    public AutorBusiness(ISender sender, IValidator<CreateAutorCommand> createValidate, IValidator<UpdateAutorCommand> updateValidate, IValidator<DeleteAutorCommand> deleteValidate)
    {
        _sender = sender;
        _createValidate = createValidate;
        _updateValidate = updateValidate;
        _deleteValidate = deleteValidate;
    }


    public async Task<RequestBase<object>> Create(CreateAutorCommand request)
    {
        var result = await _createValidate.ValidateAsync(request, opt => opt.IncludeRuleSets("NameExist"));
        if (!result.IsValid)
        {
            return new RequestBase<object>(code: HttpStatusCode.BadRequest, message: "Error", errors:  result.ResultErrors());
        }
        
        await _sender.Send(request);
        return  new RequestBase<object>();
    }
    
    public async Task<RequestBase<object>> Update(UpdateAutorCommand request)
    {
        var result = _updateValidate.Validate(request);
        if (!result.IsValid)
        {
            return new RequestBase<object>(code: HttpStatusCode.BadRequest, message: "Error", errors:  result.ResultErrors());
        }

        await _sender.Send(request);
        return new RequestBase<object>();
    }
    
    public async Task<RequestBase<object>> Delete(DeleteAutorCommand request)
    {
        var result = _deleteValidate.Validate(request);
        if (!result.IsValid)
        {
            return new RequestBase<object>(code: HttpStatusCode.BadRequest, message: "Error", errors:  result.ResultErrors());
        }
        
        await _sender.Send(request);
        return new RequestBase<object>();
    }
    
    public async Task<RequestBase<AutoresDto>> Find( int id)
    {

        var model = new FindAutorCommand(id: id);
        var result = await _sender.Send(model);
        return  new RequestBase<AutoresDto>(data:result);
    }

    public async Task<RequestBase<List<AutoresDto>>> All()
    {
        var result = await _sender.Send(new GetAllAutoresCommand());
        return  new RequestBase<List<AutoresDto>>(data:result);
    }

}