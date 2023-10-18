using System.Reflection;
using Autofac;
using AutoMapper.Contrib.Autofac.DependencyInjection;
using InterfaceCore.Core.Data;
using InterfaceCore.Core.MiddleWares.UnifyResponse;
using InterfaceCore.Core.MiddleWares.UnitOfWork;
using InterfaceCore.Core.Services;
using InterfaceCore.Core.Setting;
using Mediator.Net;
using Mediator.Net.Autofac;
using Microsoft.EntityFrameworkCore;
using Module = Autofac.Module;

namespace InterfaceCore.Core;

public class ApplicationModule : Module
{
    private readonly Assembly[] _assemblies;

    public ApplicationModule(params Assembly[] assemblies)
    {
        _assemblies = assemblies;
    }

    protected override void Load(ContainerBuilder builder)
    {
        RegisterDbContext(builder);
        
        RegisterDependency(builder);
        
        RegisterMediator(builder);
        
        RegisterSettings(builder);
        
        RegisterAutoMapper(builder);
    }
    
    private void RegisterDbContext(ContainerBuilder builder)
    {
        builder.RegisterType<ApplicationDbContext>()
            .AsSelf()
            .As<DbContext>()
            .AsImplementedInterfaces();

        builder.RegisterType<EfRepository>().As<IRepository>().InstancePerLifetimeScope();
    }

    private void RegisterDependency(ContainerBuilder builder)
    {
        foreach (var type in typeof(IService).Assembly.GetTypes()
                     .Where(t => typeof(IService).IsAssignableFrom(t) && t.IsClass))
        {
            if (typeof(IInstancePerLifetimeScopeService).IsAssignableFrom(type))
            {
                builder.RegisterType(type).AsImplementedInterfaces().InstancePerLifetimeScope();
            }
            else if (typeof(ISingletonService).IsAssignableFrom(type))
            {
                builder.RegisterType(type).AsImplementedInterfaces().SingleInstance();
            }
            else
            {
                builder.RegisterType(type).AsImplementedInterfaces().InstancePerDependency();
            }
        }
    }

    private void RegisterMediator(ContainerBuilder builder)
    {
        var mediatorBuilder = new MediatorBuilder();

        mediatorBuilder.RegisterHandlers(_assemblies);

        mediatorBuilder.ConfigureGlobalReceivePipe(c =>
        {
            c.UseUnitOfWork();
            c.UseUnifyResponse();
        });
        
        builder.RegisterMediator(mediatorBuilder);
    }

    private void RegisterSettings(ContainerBuilder builder)
    {
        var settingTypes = typeof(ApplicationModule).Assembly.GetTypes()
            .Where(t => t.IsClass && typeof(IConfigurationSetting).IsAssignableFrom(t))
            .ToArray();

        builder.RegisterTypes(settingTypes).AsSelf().SingleInstance();
    }

    private void RegisterAutoMapper(ContainerBuilder builder)
    {
        builder.RegisterAutoMapper(typeof(ApplicationModule).Assembly);
    }
}