namespace Core.CrossCuttingConcerns.Exceptions.Types;

public class BusinessException : Exception
{
    public BusinessException(string? message, string title, int statusCode)
        : base(message)
    {
        Title = title;
        StatusCode = statusCode;
    }

    public string Title { get; }
    public int StatusCode { get; }
}