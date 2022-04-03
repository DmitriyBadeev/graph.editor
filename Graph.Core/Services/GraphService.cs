using Graph.Core.Entities;
using Graph.Core.Exceptions;
using Graph.Core.Factories;
using Graph.Core.Interfaces.Repositories;
using Graph.Core.Interfaces.Services;

namespace Graph.Core.Services;

public class GraphService : IGraphService
{
    private readonly IGraphRepository _graphRepository;

    public GraphService(IGraphRepository graphRepository)
    {
        _graphRepository = graphRepository;
    }

    public void CreateNewGraph(string name)
    {
        var graph = new ElementGraph(name);
        
        _graphRepository.Save(graph);
    }

    public void CreateDefaultGraph(string name)
    {
        var graphFactory = new DefaultGraphFactory();
        var graph = graphFactory.Create(name);
        
        _graphRepository.Save(graph);
    }

    public IEnumerable<ElementGraph> GetAllGraphs()
    {
        return _graphRepository.GetAll();
    }

    public ElementGraph? Get(Guid id)
    {
        return _graphRepository.Get(id);
    }

    public void RemoveGraph(Guid id)
    {
        _graphRepository.Remove(id);
    }

    public ElementGraph CreateElement(Guid graphId, string? name, Guid typeId)
    {
        var graph = _graphRepository.Get(graphId) ?? throw new NotFoundEntityException();
        var type = graph.GetElementTypeById(typeId);
        graph.AddElement(name, type);
        
        _graphRepository.Save(graph);
        return graph;
    }
}