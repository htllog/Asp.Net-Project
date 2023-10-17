namespace InterfaceCore.Core.Data;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    
    bool ShouldSaveChange { get; set; }
}