namespace backend.Services;

using AutoMapper;
using backend.Interfaces;
using backend.DTOS.Users;
using System.Linq;
using backend.Entities;
using backend.Exceptions;
using Microsoft.Extensions.Logging;

public class UsersService : IUsersService
{
    private readonly IMapper _mapper;
    private readonly AppDbContext _context;
    private readonly ILogger<UsersService> _logger;

    public UsersService(IMapper mapper, AppDbContext context, ILogger<UsersService> logger)
    {
        _mapper = mapper;
        _context = context;
        _logger = logger;
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
        using var transaction = _context.Database.BeginTransaction();

        try {
            UsersEntity newUser = _mapper.Map<UsersEntity>(user);

            _context.Users.Add(newUser);
            _context.SaveChanges();

            transaction.Commit();

            return _mapper.Map<UsersResponseDto>(newUser);
        }
        catch (Exception ex) {
            transaction.Rollback();

            _logger.LogError(ex, "CreateUser failed. Input: {@User}", user);

            throw new Exception(ex.Message);
        }
    }

    public UsersResponseDto UpdateUser(int id, UsersResponseDto user)
    {
        using var transaction = _context.Database.BeginTransaction();

        try {

            UsersEntity? updatedUser = _context.Users.FirstOrDefault(user => user.Id == id) ?? throw new NotFoundException();

            _mapper.Map(user, updatedUser);

            _context.SaveChanges();

            transaction.Commit();

            return _mapper.Map<UsersResponseDto>(updatedUser);
        }
        catch (Exception ex) {
            transaction.Rollback();

            _logger.LogError(ex, "UpdateUser failed. Input: {@User}", user);

            throw new Exception(ex.Message);
        }
    }

    public void DeleteUser(int id)
    {
        using var transaction = _context.Database.BeginTransaction();

        try {

            UsersEntity? deleteUser = _context.Users.FirstOrDefault(user => user.Id == id);

            _context.Users.Remove(deleteUser ?? throw new NotFoundException());
            _context.SaveChanges();

            transaction.Commit();
        }
        catch (Exception ex) {
            transaction.Rollback();

            _logger.LogError(ex, "DeleteUser failed. Input: {@User}", id);

            throw new Exception(ex.Message);
        }
    }
}