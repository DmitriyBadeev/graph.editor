using Graph.Core.Entities;
using Graph.Core.Exceptions;

namespace Graph.Core.ValueObjects;

public record TypesLink
{
    public ElementType Source { get; }

    public ElementType Destination { get; }

    public TypesLink(ElementType source, ElementType destination)
    {
        if (!source.IsLinkedWith(destination))
        {
            throw new LinkDoesNotExistException();
        }

        (Source, Destination) = (source, destination);
    }
}