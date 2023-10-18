using InterfaceCore.Core.Services.Users;
using InterfaceCore.Message.Requests.User;
using Mediator.Net.Context;
using Mediator.Net.Contracts;

namespace InterfaceCore.Core.Handlers.Request;

public class GetUserRequestHandler : IRequestHandler<GetUserRequest, GetUserResponse>
{
    private readonly IUserService _userService;

    public GetUserRequestHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<GetUserResponse> Handle(IReceiveContext<GetUserRequest> context,
        CancellationToken cancellationToken)
    {
        return await _userService.GetAllUserAsync(context.Message, cancellationToken).ConfigureAwait(false);
    }
}