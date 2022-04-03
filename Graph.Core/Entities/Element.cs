using Graph.Core.ValueObjects;

namespace Graph.Core.Entities;

public class Element : EntityBase
{
    private readonly List<Element> _linksWithElements;

    public Element(string? name, ElementType type)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Type = type ?? throw new ArgumentNullException(nameof(type));
        _linksWithElements = new List<Element>();
    }
    
    public string Name { get; }

    public ElementType Type { get; }
    
    public IEnumerable<Element> LinkedElements => _linksWithElements.AsReadOnly();

    public IEnumerable<ElementsLink> Links => 
        LinkedElements.Select(linkedElement => new ElementsLink(this, linkedElement));

    public void UpdateLinksWithElements(IEnumerable<Element> elements)
    {
        _linksWithElements.Clear();

        foreach (var element in elements)
        {
            TryLinkWithElement(element);
        }
    }

    public bool IsLinkedWith(Element element)
    {
        if (element == null) throw new ArgumentNullException(nameof(element));
        
        return LinkedElements.Contains(element);
    }
    
    private bool TryLinkWithElement(Element element)
    {
        if (element == null) throw new ArgumentNullException(nameof(element));

        if (LinkedElements.Contains(element)) return false;

        var hasLink = Type.IsLinkedWith(element.Type);
        if (!hasLink) return false;
        
        _linksWithElements.Add(element);
        return true;
    }
    
    public override string ToString()
    {
        return $"Элемент '{Name}' с типом '{Type.Name}'";
    }
}