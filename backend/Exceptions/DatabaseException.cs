namespace backend.Exceptions;

public class DatabaseException : Exception
{
    public object? Input { get; }

    public DatabaseException(object? input, Exception innerException)
        : base(innerException.Message, innerException)
    {
        Input = input;
    }
}
