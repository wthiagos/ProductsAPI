namespace ProductsAPI.Exceptions;

public class ProductNotFoundException: Exception
{
    private readonly string? _message;
    private readonly Exception? _innerException;
    
    public ProductNotFoundException(string? message)
    {
        _message = message;
    }
    
    public ProductNotFoundException(string? message, Exception? innerException)
    {
        _message = message;
        _innerException = innerException;
    }
}