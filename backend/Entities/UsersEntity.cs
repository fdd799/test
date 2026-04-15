namespace backend.Entities;

public class UsersEntity
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
}