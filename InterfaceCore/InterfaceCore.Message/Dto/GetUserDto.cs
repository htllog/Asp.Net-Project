namespace InterfaceCore.Message.Dto;

public class GetUserDto
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public DateTime? CreateAt { get; set; }
}