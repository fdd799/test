using backend.DTOS.Users;

namespace backend.Interfaces;

public interface IUsersService
{
    List<UsersResponseDto> GetUsers();

    UsersResponseDto GetUserById(int id);

    UsersResponseDto CreateUser(UsersResponseDto user);

    UsersResponseDto UpdateUser(int id, UsersResponseDto user);

    void DeleteUser(int id);
}