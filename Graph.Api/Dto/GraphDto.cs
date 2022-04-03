namespace Graph.Api.Dto;

public class GraphDto
{
    public Guid Id { get; set; }
    
    public string? Name { get; set; }
    
    public IEnumerable<ElementDto>? Elements { get; set; }
    
    public IEnumerable<LinkDto>? Links { get; set; }
    
    public IEnumerable<LinkDto>? TypesLinks { get; set; }
    
    public IEnumerable<TypeDto>? ElementsTypes { get; set; }
}