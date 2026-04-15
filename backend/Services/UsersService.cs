namespace backend.Services;

using AutoMapper;
using backend.Interfaces;
using backend.DTOS.Users;
using System.Linq;
using System.Threading.Tasks;
using backend.Entities;
using backend.Exceptions;

public class UsersService : IUsersService
{
    private readonly IMapper _mapper;
    private readonly AppDbContext _context;

    public UsersService(IMapper mapper, AppDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public List<UsersResponseDto> GetUsers()
    {
        List<UsersEntity> users = _context.Users.ToList();

        return _mapper.Map<List<UsersResponseDto>>(users);
    }

    public UsersResponseDto GetUserById(int id)
    {
        UsersEntity? user = _context.Users.FirstOrDefault(user => user.Id == id);
        
        return _mapper.Map<UsersResponseDto>(user ?? throw new NotFoundException());
    }

    public UsersResponseDto CreateUser(CreateUserDto user)
    {
        UsersEntity newUser = _mapper.Map<UsersEntity>(user);

        _context.Users.Add(newUser);
        _context.SaveChanges();

        return _mapper.Map<UsersResponseDto>(newUser);
    }

    public UsersResponseDto UpdateUser(int id, UsersResponseDto user)
    {
        UsersEntity? updatedUser = _context.Users.FirstOrDefault(user => user.Id == id) ?? throw new NotFoundException();

        _mapper.Map(user, updatedUser);

        _context.SaveChanges();

        return _mapper.Map<UsersResponseDto>(updatedUser);
    }

    public void DeleteUser(int id)
    {
        UsersEntity? deleteUser = _context.Users.FirstOrDefault(user => user.Id == id);

        _context.Users.Remove(deleteUser ?? throw new NotFoundException());
        _context.SaveChanges();
    }
}