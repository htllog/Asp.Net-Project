using InterfaceCore.Message.Dto;
using Mediator.Net.Contracts;

namespace InterfaceCore.Core.Events.User;

public class CreateUserEvent : IEvent
{
    public CreateUserDto UserDto { get; set; }
}