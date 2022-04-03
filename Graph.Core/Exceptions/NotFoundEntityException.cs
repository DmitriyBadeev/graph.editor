namespace Graph.Core.Exceptions;

public class NotFoundEntityException : Exception
{
    private const string NotFoundMessage = "Сущность не найдена";

    public NotFoundEntityException(string? message = NotFoundMessage) : base(message)
    {
    }
}