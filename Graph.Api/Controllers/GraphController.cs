using AutoMapper;
using Graph.Api.Dto;
using Graph.Core.Entities;
using Graph.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Graph.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class GraphController : Controller
{
    private readonly IGraphService _graphService;
    private readonly IMapper _mapper;

    public GraphController(IGraphService graphService, IMapper mapper)
    {
        _graphService = graphService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public IEnumerable<GraphInfoDto> GetAll()
    {
        var graphs = _graphService.GetAllGraphs();

        return _mapper.Map<IEnumerable<GraphInfoDto>>(graphs);
    }
    
    [HttpGet("{graphId}")]
    public ActionResult<GraphDto> Get([FromRoute] Guid graphId)
    {
        var graph = _graphService.Get(graphId);

        if (graph is null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<GraphDto>(graph));
    }

    
}