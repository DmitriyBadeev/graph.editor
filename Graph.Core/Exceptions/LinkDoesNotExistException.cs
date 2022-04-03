namespace Graph.Core.Exceptions;

public class LinkDoesNotExistException : Exception
{
    private const string Message = "Ссылки между элементами не существует";

    public LinkDoesNotExistException(string? message = Message) : base(message)
    {
    }
}