using AutoMapper;
using Graph.Api.Dto;
using Graph.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Graph.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ElementController : Controller
{
    private readonly IGraphService _graphService;
    private readonly IMapper _mapper;

    public ElementController(IGraphService graphService, IMapper mapper)
    {
        _graphService = graphService;
        _mapper = mapper;
    }
    
    [HttpPost]
    public GraphInfoDto Create([FromBody] CreateElementDto data)
    {
        var graph = _graphService.CreateElement(data.GraphId, data.Name, data.TypeId);

        return _mapper.Map<GraphInfoDto>(graph);
    }
}