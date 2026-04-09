namespace backend.Interfaces;

using backend.DTOS.Hello;

public interface IHelloService
{
    HelloResponseDto GetHello();
}