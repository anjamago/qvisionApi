using System.Net;
using Application.Autores.Create;
using Application.Autores.GetAll;
using Domain.Dtos;
using Domain.Dtos.Request;
using FluentValidation;
using MediatR;

namespace Application.Autores;



public class AutorBusiness : IAutorBusiness
{
    private readonly ISender _sender;
    private readonly IValidator<CreateAutorCommand> _validator;

    public AutorBusiness(ISender sender, IValidator<CreateAutorCommand> validator)
    {
        _sender = sender;
        _validator = validator;
    }


    public async Task<RequestBase<object>> Create(CreateAutorCommand request)
    {
        var result = await _validator.ValidateAsync(request, opt => opt.IncludeRuleSets("NameExist"));
        if (!result.IsValid)
        {
            List<string> errors = result.Errors.Select(s =>
                s.ErrorMessage
            ).ToList();
            return new RequestBase<object>(code: HttpStatusCode.BadRequest, message: "Error", errors: errors);
        }
        
        await _sender.Send(request);
        return  new RequestBase<object>();
    }
    
    public async Task<RequestBase<object>> Update(CreateAutorCommand request)
    {
        throw new InvalidOperationException();
    }
    
    public async Task<RequestBase<object>> Delete(CreateAutorCommand request)
    {
        throw new InvalidOperationException();
    }
    
    public async Task<RequestBase<AutoresDto>> Find(CreateAutorCommand request)
    {
        
        
        await _sender.Send(request);
        return  new RequestBase<AutoresDto>();
    }

    public async Task<RequestBase<List<AutoresDto>>> All()
    {
        var result = await _sender.Send(new GetAllAutoresCommand());
        return  new RequestBase<List<AutoresDto>>(data:result);
    }

}