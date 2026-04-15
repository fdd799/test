using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace backend.Models;

public class Users
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }

    public bool IsValidEmail()
    {
        return Email.Contains("@");
    }
}