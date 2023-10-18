using System.Reflection;
using InterfaceCore.Core.Domain;
using Microsoft.EntityFrameworkCore;
using InterfaceCore.Core.Setting.System;

namespace InterfaceCore.Core.Data;

public class ApplicationDbContext : DbContext, IUnitOfWork
{
    private readonly ConnectionString _connectionString;

    public ApplicationDbContext(ConnectionString connectionString)
    {
        _connectionString = connectionString;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql(_connectionString.Value, new MySqlServerVersion(new Version(5, 7, 0)));
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        typeof(ApplicationDbContext).GetTypeInfo().Assembly.GetTypes()
            .Where(t => typeof(IEntity).IsAssignableFrom(t) && t.IsClass).ToList()
            .ForEach(x =>
            {
                if (modelBuilder.Model.FindEntityType(x) == null)
                    modelBuilder.Model.AddEntityType(x);
            });
    }
    
    public bool ShouldSaveChanges { get; set; }
}