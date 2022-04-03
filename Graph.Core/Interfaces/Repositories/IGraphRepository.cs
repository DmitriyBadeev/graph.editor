using Graph.Core.Entities;

namespace Graph.Core.Interfaces.Repositories;

public interface IGraphRepository
{
    IEnumerable<ElementGraph> GetAll();
    ElementGraph? Get(Guid id);
    void Save(ElementGraph graph);
    void Remove(Guid id);
}