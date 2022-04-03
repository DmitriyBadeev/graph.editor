using Graph.Core.Entities;

namespace Graph.Core.Factories;

public class DefaultGraphFactory
{
    public ElementGraph Create(string name)
    {
        var graph = new ElementGraph(name);
        ConfigureGraph(graph);

        return graph;
    }

    private void ConfigureGraph(ElementGraph graph)
    {
        var a = graph.AddType("A");
        
        var o1 = graph.AddType("O1");
        var o2 = graph.AddType("O2");
        var o3 = graph.AddType("O3");
        var o4 = graph.AddType("O4");
        var o5 = graph.AddType("O5");
        var o6 = graph.AddType("O6");

        var b1 = graph.AddType("B1");
        var b2 = graph.AddType("B2");
        var b3 = graph.AddType("B3");
        
        var c1 = graph.AddType("C1");
        var c2 = graph.AddType("C2");
        var c3 = graph.AddType("C3");
        var c4 = graph.AddType("C4");
        var c5 = graph.AddType("C5");
        
        var x1 = graph.AddType("X1");
        var x2 = graph.AddType("X2");
        var x3 = graph.AddType("X3");

        a.AddLinksWith(o1, o2, o3, o4, o5, o6, b1, b2, b3, c1, c2, c3, c4, c5, x1, x2, x3);
        
        o6.AddLinksWith(a, o1, o2, o3, o4, o5, b1, b2, b3, c1, c2, c3, c4, c5);
        o1.AddLinksWith(a, o5, b2, c5, x1);
        o2.AddLinksWith(a, o4, o5, b2, c5, x2);
        o3.AddLinksWith(a, o5, o1, o6, c2, x3);
        o5.AddLinksWith(a, o1, o3, o2, o6, c1, x3);
        
        b1.AddLinksWith(a, o6);
        b2.AddLinksWith(a, o1, o2, o6);
        b3.AddLinksWith(a, o4, c4, c3);
        
        c1.AddLinksWith(a, o6, o5, x3);        
        c2.AddLinksWith(a, o3, o6);        
        c3.AddLinksWith(a, o6, o2, b3);        
        c4.AddLinksWith(a, o6, b3);
        c5.AddLinksWith(a, o6, o1, b2);
        
        x1.AddLinksWith(a, o1);
        x2.AddLinksWith(a, o2);
        x3.AddLinksWith(a, o3, o5);
    }
}