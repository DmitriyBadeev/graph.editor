using Graph.Core.Entities;
using Graph.Core.Factories;
using Graph.Core.Interfaces.Repositories;

namespace Graph.Infrastructure.Repositories;

public class InMemoryGraphRepository : IGraphRepository
{
    private readonly List<ElementGraph> _graphs;

    public InMemoryGraphRepository()
    {
        var graphFactory = new DefaultGraphFactory();
        _graphs = new List<ElementGraph>
        {
            graphFactory.Create("Граф элементов")
        };
    }

    public IEnumerable<ElementGraph> GetAll()
    {
        return _graphs;
    }

    public ElementGraph? Get(Guid id)
    {
        return _graphs.Find(g => g.Id == id);
    }

    public void Save(ElementGraph graph)
    {
        var existGraph = _graphs.Find(g => g.Id == graph.Id); 
        
        if (existGraph != null) _graphs.Remove(graph);
        _graphs.Add(graph);
    }

    public void Remove(Guid id)
    {
        var existGraph = _graphs.Find(g => g.Id == id);
        
        if (existGraph != null) _graphs.Remove(existGraph);
    }
}