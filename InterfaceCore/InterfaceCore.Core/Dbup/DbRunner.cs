using System.Reflection;
using DbUp;
using InterfaceCore.Core.Setting.System;

namespace InterfaceCore.Core.Dbup;

public class DbRunner
{
    private readonly ConnectionString _connectionString;

    public DbRunner(ConnectionString connectionString)
    {
        _connectionString = connectionString;
    }

    public void RunMigration()
    {
        EnsureDatabase.For.MySqlDatabase(_connectionString.Value);

        var upgrader = DeployChanges.To.MySqlDatabase(_connectionString.Value)
            .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
            .LogToAutodetectedLog()
            .Build();

        var result = upgrader.PerformUpgrade();
        
        if (!result.Successful)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(result.Error);
            Console.ResetColor();
        }

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Database migration completed successfully.");
        Console.ResetColor();
    }
    
    public void CustomDbUpOperation()
    {
        Console.WriteLine("Custom DbUp operation completed successfully.");
    }
}