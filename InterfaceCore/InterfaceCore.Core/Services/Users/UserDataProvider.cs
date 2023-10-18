using AutoMapper;
using InterfaceCore.Core.Data;
using InterfaceCore.Message.Dto;
using InterfaceCore.Core.Domain;
using InterfaceCore.Core.Events.User;
using InterfaceCore.Message.Requests.User;

namespace InterfaceCore.Core.Services.Users;

public interface IUserDataProvider : IInstancePerLifetimeScopeService
{
    Task<List<User>> GetAllUserAsync(GetUserRequest getUserRequest, CancellationToken cancellationToken);
}

public class UserDataProvider : IUserDataProvider
{
    private readonly IMapper _mapper;
    private readonly IRepository _repository;
    private readonly ApplicationDbContext _applicationDbContext;

    public UserDataProvider(IMapper mapper, IRepository repository, ApplicationDbContext applicationDbContext)
    {
        _mapper = mapper;
        _repository = repository;
        _applicationDbContext = applicationDbContext;
    }

    public async Task<List<User>> GetAllUserAsync(GetUserRequest getUserRequest, CancellationToken cancellationToken)
    {
        return await _repository.GetAllAsync<User>(cancellationToken).ConfigureAwait(false);
    }
}