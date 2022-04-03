namespace Graph.Core.Exceptions;

public class NotFoundElementTypeException : NotFoundEntityException
{
    private const string InvalidElementTypeMessage = "Тип элемента не существует в графе";

    public NotFoundElementTypeException(string? message = InvalidElementTypeMessage) : base(message)
    {
    }
}