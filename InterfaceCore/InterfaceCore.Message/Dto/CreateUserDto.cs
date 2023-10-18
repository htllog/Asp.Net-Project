namespace InterfaceCore.Message.Dto;

public class CreateUserDto
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public DateTime? CreateAt { get; set; }
}