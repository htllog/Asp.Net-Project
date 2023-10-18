using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InterfaceCore.Core.Domain;

[Table("users")]
public class User : IEntity
{
    [Key]
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    [Column("createdAt")]
    public DateTime CreatedAt { get; set; }
}