namespace Application.Autores;

public class IAutoresBusiness
{
    Task<RequestBase<object>> Create(CreateCommand request);
    Task<RequestBase<object>> Update(CreateCommand request);
    Task<RequestBase<object>> Delete(CreateCommand request);
    Task<RequestBase<AutoresDto>> Find(CreateCommand request);
    Task<RequestBase<List<AutoresDto>>> All();
}

