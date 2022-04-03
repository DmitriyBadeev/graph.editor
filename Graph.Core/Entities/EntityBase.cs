namespace Graph.Core.Entities;

public abstract class EntityBase
{
    public Guid Id { get; }

    protected EntityBase()
    {
        Id = Guid.NewGuid();
    }
    
    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
    
    public override bool Equals(object? obj)
    {
        if (obj is EntityBase entity)
        {
            return entity.Id == Id;
        }
        
        return false;
    }
}