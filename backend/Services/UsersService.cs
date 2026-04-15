namespace backend.Services;

using backend.Interfaces;
using backend.DTOS.Users;
using System.Linq;
using System.Threading.Tasks;
using backend.Entities;
using backend.Exceptions;

public class UsersService : IUsersService
{
    private readonly AppDbContext _context;

    public UsersService(AppDbContext context)
    {
        _context = context;
    }

    public List<UsersResponseDto> GetUsers()
    {
        return _context.Users.Select(user => new UsersResponseDto{
            Id = user.Id,
            Name = user.Name,
            Email = user.Email
        }).ToList();
    }

    public UsersResponseDto GetUserById(int id)
    {
        var user = _context.Users.Where(user => user.Id == id)
                            .Select(user => new UsersResponseDto{
                                Id = user.Id,
                                Name = user.Name,
                                Email = user.Email
                            })
                            .FirstOrDefault();
        
        return user ?? throw new NotFoundException();
    }

    public UsersResponseDto CreateUser(CreateUserDto user)
    {
        var newUser = new UsersEntity{
            Name = user.Name,
            Email = user.Email
        };

        _context.Users.Add(newUser);
        _context.SaveChanges();

        return new UsersResponseDto{
            Id = newUser.Id,
            Name = newUser.Name,
            Email = newUser.Email
        };
    }

    public UsersResponseDto UpdateUser(int id, UsersResponseDto user)
    {
        var updatedUser = _context.Users.FirstOrDefault(user => user.Id == id);

        if(updatedUser == null)
            throw new NotFoundException();

        updatedUser.Name = user.Name;
        updatedUser.Email = user.Email;

        _context.SaveChanges();
        
        return new UsersResponseDto{
            Id = updatedUser.Id,
            Name = updatedUser.Name,
            Email = updatedUser.Email
        };
    }

    public void DeleteUser(int id)
    {
        var deleteUser = _context.Users.FirstOrDefault(user => user.Id == id);

        if(deleteUser == null)
            throw new NotFoundException();

        _context.Users.Remove(deleteUser);
        _context.SaveChanges();
    }
}