using Graph.Core.Entities;

namespace Graph.Core.Test.Helpers;

public class TestGraphFactory
{
    public ElementType A { get; private set; }
    public ElementType B { get; private set; }
    public ElementType C { get; private set; }
    public ElementType D { get; private set; }
    
    public ElementGraph Create()
    {
        var graph = new ElementGraph("Тестовый граф");
        A = graph.AddType("a");
        B = graph.AddType("b");
        C = graph.AddType("c");
        D = graph.AddType("d");
        
        A.AddLinksWith(B, D);
        B.AddLinksWith(C);
        C.AddLinksWith(A);
        D.AddLinksWith(C, A);
        
        return graph;
    }
}