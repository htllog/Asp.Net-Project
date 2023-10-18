using System.Net;
using Mediator.Net.Contracts;

namespace InterfaceCore.Message.Responses;

public class AppResponse<T> : AppResponse
{
    public T Data { get; set; }
}

public class AppResponse : IResponse
{
    public HttpStatusCode Code { get; set; }
    
    public string Msg { get; set; }
}