using InterfaceCore.Message.Dto;
using InterfaceCore.Message.Responses;
using Mediator.Net.Contracts;

namespace InterfaceCore.Message.Commands.User;

public class CreateUserCommand : ICommand
{
    public CreateUserDto User { get; set; }
}

public class CreateUserResponse : AppResponse<CreateUserDto>
{
}