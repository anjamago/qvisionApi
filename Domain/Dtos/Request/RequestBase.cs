using System.Net;

namespace Domain.Dtos.Request;

public class RequestBase<TEntity>
{
    public RequestBase(HttpStatusCode code = HttpStatusCode.OK, string message="Ok", TEntity data = default, List<string> errors=null)
    {
        Code = (int)code;
        Message = message;
        Data = data;
        Errors = errors;
    }

    public int Code { set; get; }
    public string Message { set; get; }
    public TEntity Data { set; get; }
    public List<string> Errors { set; get; }
    
}