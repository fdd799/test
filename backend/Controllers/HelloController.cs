namespace backend.Controllers;

using Microsoft.AspNetCore.Mvc;
using backend.Interfaces;
using backend.DTOS.Hello;

[ApiController]
[Route("api/[controller]")]
public class HelloController : ControllerBase
{
    private readonly IHelloService _helloService;

    public HelloController(IHelloService helloService)
    {
        _helloService = helloService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        HelloResponseDto helloResponse = _helloService.GetHello();
        return Ok(helloResponse);
    }
}