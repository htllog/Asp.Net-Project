using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InterfaceCore.Core.Domain;

[Table("users")]
public class User : IEntity
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    public string Name { get; set; }
    
    [Column("created_at")]
    public DateTime CreatedAt { get; set; }
}