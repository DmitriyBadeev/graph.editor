namespace Graph.Api.Dto;

public class ElementDto
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public TypeDto? Type { get; set; }
}