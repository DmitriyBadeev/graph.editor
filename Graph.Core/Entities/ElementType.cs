using Graph.Core.ValueObjects;

namespace Graph.Core.Entities;

public class ElementType : EntityBase
{
    private readonly List<ElementType> _linkWithTypes;

    public ElementType(string name)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        _linkWithTypes = new List<ElementType>();
    }
    
    public string Name { get; }
    
    public IEnumerable<ElementType> LinkedTypes => _linkWithTypes.AsReadOnly();
    
    public IEnumerable<TypesLink> Links => 
        LinkedTypes.Select(linkedElement => new TypesLink(this, linkedElement));

    public bool IsLinkedWith(ElementType type)
    {
        return LinkedTypes.Contains(type);
    }

    public void AddLinksWith(ElementType type)
    {
        if (type == null) throw new ArgumentNullException(nameof(type));
        
        if (!LinkedTypes.Contains(type)) _linkWithTypes.Add(type);
    }

    public void AddLinksWith(params ElementType[] types)
    {
        foreach (var type in types) AddLinksWith(type);
    }

    public override string ToString()
    {
        return $"Тип элемента '{Name}'";
    }
}