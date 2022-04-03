namespace Graph.Api.Dto;

public class CreateElementDto
{
    public string? Name { get; set; }

    public Guid TypeId { get; set; }
    
    public Guid GraphId { get; set; }
}