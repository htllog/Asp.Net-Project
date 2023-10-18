namespace InterfaceCore.Core.Services;

public interface IService
{
}

public interface IInstancePerLifetimeScopeService : IService
{
}

public interface ISingletonService : IService
{
}