using AutoMapper;
using InterfaceCore.Core.Events.User;
using InterfaceCore.Message.Commands.User;
using InterfaceCore.Message.Dto;
using InterfaceCore.Message.Requests.User;

namespace InterfaceCore.Core.Services.Users;

public interface IUserService : IInstancePerLifetimeScopeService
{
    Task<GetUserResponse> GetAllUserAsync(GetUserRequest getUserRequest, CancellationToken cancellationToken);
}

public class UserService : IUserService
{
    private readonly IMapper _mapper;
    private readonly IUserDataProvider _userDataProvider;

    public UserService(IMapper mapper, IUserDataProvider userDataProvider)
    {
        _mapper = mapper;
        _userDataProvider = userDataProvider;
    }

    public async Task<GetUserResponse> GetAllUserAsync(GetUserRequest getUserRequest,
        CancellationToken cancellationToken)
    {
        var users = await _userDataProvider.GetAllUserAsync(getUserRequest, cancellationToken).ConfigureAwait(false);

        return new GetUserResponse
        {
            Data = _mapper.Map<List<GetUserDto>>(users)
        };
    }
}