using Graph.Core.Entities;
using Graph.Core.Exceptions;

namespace Graph.Core.ValueObjects;

public record ElementsLink
{
    public Element Source { get; }

    public Element Destination { get; }

    public ElementsLink(Element source, Element destination)
    {
        if (!source.IsLinkedWith(destination))
        {
            throw new LinkDoesNotExistException();
        }

        (Source, Destination) = (source, destination);
    }
}