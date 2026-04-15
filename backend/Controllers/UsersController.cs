namespace backend.Controllers;

using Microsoft.AspNetCore.Mvc;
using backend.Interfaces;
using backend.DTOS.Users;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUsersService _usersService;

    public UsersController(IUsersService usersService)
    {
        _usersService = usersService;
    }

    [HttpGet]
    public IActionResult GetUsers()
    {
        List<UsersResponseDto> users = _usersService.GetUsers();

        return Ok(users);
    }

    [HttpGet("{id}")]
    public IActionResult GetUserById(int id)
    {
        UsersResponseDto user = _usersService.GetUserById(id);

        return Ok(user);
    }

    [HttpPost]
    public IActionResult CreateUser(UsersResponseDto user)
    {
        UsersResponseDto newUser = _usersService.CreateUser(user);

        return Ok(newUser);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateUser(int id, UsersResponseDto user)
    {
        UsersResponseDto updatedUser = _usersService.UpdateUser(id, user);

        return Ok(updatedUser);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteUser(int id)
    {
        _usersService.DeleteUser(id);

        return Ok("User deleted successfully");
    }
}