namespace backend.Middlewares;

using backend.Exceptions;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (NotFoundException)
        {
            context.Response.StatusCode = StatusCodes.Status404NotFound;
            await context.Response.WriteAsJsonAsync(new
            {
                message = "Resource not found"
            });
        }
        catch (DatabaseException ex)
        {
            var method = ex.TargetSite;
            var className = method?.DeclaringType?.Name ?? "Unknown";
            var methodName = method?.Name ?? "Unknown";

            _logger.LogError(ex.InnerException, "{Class}.{Method} failed. Input: {@Input}", className, methodName, ex.Input);

            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            await context.Response.WriteAsJsonAsync(new
            {
                message = "Internal server error"
            });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unexpected error occurred");

            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            await context.Response.WriteAsJsonAsync(new
            {
                message = "Internal server error"
            });
        }
    }
}