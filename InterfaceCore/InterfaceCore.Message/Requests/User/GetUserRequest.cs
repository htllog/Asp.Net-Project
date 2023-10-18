using InterfaceCore.Message.Dto;
using InterfaceCore.Message.Responses;
using Mediator.Net.Contracts;

namespace InterfaceCore.Message.Requests.User;

public class GetUserRequest : IRequest
{
    public int Id { get; set; }
}

public class GetUserResponse : AppResponse<List<GetUserDto>>
{
}