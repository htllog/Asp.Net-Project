using Mediator.Net.Context;
using Mediator.Net.Contracts;
using InterfaceCore.Core.Services.Users;
using InterfaceCore.Message.Commands.User;

namespace InterfaceCore.Core.Handlers.Commands;

// public class CrateUserCommandHandler : ICommandHandler<CreateUserCommand, CreateUserResponse>
// {
//     private IUserService _userService;
//
//     public CrateUserCommandHandler(IUserService userService)
//     {
//         _userService = userService;
//     }
//
//     public async Task<CreateUserResponse> Handle(IReceiveContext<CreateUserCommand> context, CancellationToken cancellationToken)
//     {
//         var @event = await _userService.CreateUserAsync(context.Message, cancellationToken).ConfigureAwait(false);
//         
//         await context.PublishAsync(@event, cancellationToken).ConfigureAwait(false);
//
//         return new CreateUserResponse()
//         {
//             Data = @event.UserDto
//         };
//     }
// }