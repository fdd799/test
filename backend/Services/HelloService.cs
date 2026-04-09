namespace backend.Services;

using backend.Interfaces;
using backend.DTOS.Hello;

public class HelloService : IHelloService
{
    public HelloResponseDto GetHello()
    {
        return new HelloResponseDto { Message = "Hello, World!" };
    }
}