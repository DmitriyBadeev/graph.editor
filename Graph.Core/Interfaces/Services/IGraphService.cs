using Graph.Core.Entities;

namespace Graph.Core.Interfaces.Services;

public interface IGraphService
{
    public void CreateNewGraph(string name);
    public void CreateDefaultGraph(string name);
    public IEnumerable<ElementGraph> GetAllGraphs();
    public ElementGraph? Get(Guid id);
    public void RemoveGraph(Guid id);

    ElementGraph CreateElement(Guid graphId, string? name, Guid typeId);
}