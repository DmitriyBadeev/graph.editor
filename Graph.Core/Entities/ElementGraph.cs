using Graph.Core.Exceptions;
using Graph.Core.ValueObjects;

namespace Graph.Core.Entities;

public class ElementGraph : EntityBase
{
    private readonly List<Element> _elements;
    private readonly List<ElementType> _elementTypes;

    public ElementGraph(string name)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        _elements = new List<Element>();
        _elementTypes = new List<ElementType>();
    }
    
    public string Name { get; }

    public IEnumerable<Element> Elements => _elements.AsReadOnly();
    public IEnumerable<ElementType> ElementsTypes => _elementTypes.AsReadOnly();
    public IEnumerable<ElementsLink> Links => Elements.SelectMany(element => element.Links);
    
    public IEnumerable<TypesLink> TypesLinks => ElementsTypes.SelectMany(element => element.Links);

    public ElementType GetElementTypeById(Guid id)
    {
        return ElementsTypes.FirstOrDefault(t => t.Id == id) ?? throw new NotFoundElementTypeException();
    }
    
    public ElementType AddType(string name)
    {
        if (name == null) throw new ArgumentNullException(nameof(name));

        var type = new ElementType(name);
        _elementTypes.Add(type);

        return type;
    }

    public void RemoveType(ElementType type)
    {
        if (type == null) throw new ArgumentNullException(nameof(type));
        if (!ElementsTypes.Contains(type)) throw new NotFoundElementTypeException();

        _elementTypes.Remove(type);
        _elements.RemoveAll(e => e.Type.Id == type.Id);
        UpdateGraphLinks();
    }
    
    public Element AddElement(string? name, ElementType type)
    {
        if (name == null) throw new ArgumentNullException(nameof(name));
        if (type == null) throw new ArgumentNullException(nameof(type));
        if (!ElementsTypes.Contains(type)) throw new NotFoundElementTypeException();

        var element = new Element(name, type);
        _elements.Add(element);
        UpdateGraphLinks();
        
        return element;
    }

    public void RemoveElement(Element element)
    {
        if (element == null) throw new ArgumentNullException(nameof(element));

        _elements.Remove(element);
        UpdateGraphLinks();
    }

    private void UpdateGraphLinks()
    {
        foreach (var element in Elements)
        {
            element.UpdateLinksWithElements(Elements);
        }
    }
    
    public override string ToString()
    {
        return $"Граф '{Name}'";
    }
}