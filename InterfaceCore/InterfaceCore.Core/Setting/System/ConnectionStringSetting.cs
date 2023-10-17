using Microsoft.Extensions.Configuration;

namespace InterfaceCore.Core.Setting.System;

public class ConnectionString : IConfigurationSetting<string>
{
    public ConnectionString(IConfiguration configuration)
    {
        Value = configuration.GetConnectionString("DefaultConnectionString");
    }
    
    public string Value { get; set; }
}