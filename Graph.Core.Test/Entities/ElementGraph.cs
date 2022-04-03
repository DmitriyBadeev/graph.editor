using System.Linq;
using Graph.Core.Factories;
using Graph.Core.Test.Helpers;
using NUnit.Framework;

namespace Graph.Core.Test.Entities;

public class Tests
{
    [Test]
    public void CreateDefaultGraph()
    {
        var graphFactory = new DefaultGraphFactory();
        var graph = graphFactory.Create("Тестовый граф");

        var countLinksOfA = graph.ElementsTypes.FirstOrDefault(e => e.Name == "A")?.LinkedTypes.Count();

        var expectedCountElementsInDefaultGraph = 18;
        Assert.AreEqual(expectedCountElementsInDefaultGraph, graph.ElementsTypes.Count());
        Assert.AreEqual(expectedCountElementsInDefaultGraph - 1, countLinksOfA);
    }

    [Test]
    public void CreateElement()
    {
        var factory = new TestGraphFactory();
        var graph = factory.Create();

        var element = graph.AddElement("el1", factory.A);
        
        Assert.AreEqual(0,element.LinkedElements.Count());
        Assert.AreEqual(1, graph.Elements.Count());
        Assert.AreEqual(4, graph.ElementsTypes.Count());
    }
    
    [Test]
    public void LinkBetweenElements()
    {
        var factory = new TestGraphFactory();
        var graph = factory.Create();

        var elementA = graph.AddElement("elA", factory.A);
        var elementD = graph.AddElement("elD", factory.D);
        
        Assert.AreEqual(1, elementA.LinkedElements.Count());
        Assert.AreEqual(elementD.Name,elementA.LinkedElements.First().Name);
        
        Assert.AreEqual(1, elementD.LinkedElements.Count());
        Assert.AreEqual(elementA.Name, elementD.LinkedElements.First().Name);

        Assert.AreEqual(2, graph.Elements.Count());
        Assert.AreEqual(4,graph.ElementsTypes.Count());
    }
    
    [Test]
    public void LinkBetweenAllElements()
    {
        var factory = new TestGraphFactory();
        var graph = factory.Create();

        var elementA = graph.AddElement("elA", factory.A);
        var elementB = graph.AddElement("elB", factory.B);
        var elementC = graph.AddElement("elC", factory.C);
        var elementD = graph.AddElement("elD", factory.D);
        
        Assert.AreEqual(2, elementA.LinkedElements.Count());
        Assert.AreEqual(elementB.Name, elementA.LinkedElements.First().Name);
        Assert.AreEqual(elementD.Name, elementA.LinkedElements.Last().Name);
        
        Assert.AreEqual(1, elementB.LinkedElements.Count());
        Assert.AreEqual(elementC.Name, elementB.LinkedElements.First().Name);

        Assert.AreEqual(1, elementC.LinkedElements.Count());
        Assert.AreEqual(elementA.Name, elementC.LinkedElements.First().Name);
        
        Assert.AreEqual(2, elementD.LinkedElements.Count());
        Assert.AreEqual(elementA.Name, elementD.LinkedElements.First().Name);
        Assert.AreEqual(elementC.Name, elementD.LinkedElements.Last().Name);

        Assert.AreEqual(4, graph.Elements.Count());
        Assert.AreEqual(4, graph.ElementsTypes.Count());
    }
    
    [Test]
    public void RemoveElement()
    {
        var factory = new TestGraphFactory();
        var graph = factory.Create();

        var elementA = graph.AddElement("elA", factory.A);
        var elementB = graph.AddElement("elB", factory.B);
        var elementC = graph.AddElement("elC", factory.C);
        var elementD = graph.AddElement("elD", factory.D);
        
        Assert.AreEqual(4, graph.Elements.Count());
        graph.RemoveElement(elementA);
        
        Assert.AreEqual(3, graph.Elements.Count());
        
        Assert.AreEqual(1, elementB.LinkedElements.Count());
        Assert.AreEqual(elementC.Name, elementB.LinkedElements.First().Name);

        Assert.AreEqual(0, elementC.LinkedElements.Count());
        
        Assert.AreEqual(1, elementD.LinkedElements.Count());
        Assert.AreEqual(elementC.Name, elementD.LinkedElements.First().Name);
    }
    
    [Test]
    public void RemoveType()
    {
        var factory = new TestGraphFactory();
        var graph = factory.Create();

        var elementA = graph.AddElement("elA", factory.A);
        var elementB = graph.AddElement("elB", factory.B);
        var elementC = graph.AddElement("elC", factory.C);
        var elementD = graph.AddElement("elD", factory.D);
        
        Assert.AreEqual(4, graph.Elements.Count());
        graph.RemoveType(factory.A);
        
        Assert.AreEqual(3, graph.Elements.Count());
        Assert.AreEqual(3, graph.ElementsTypes.Count());
        
        Assert.AreEqual(1, elementB.LinkedElements.Count());
        Assert.AreEqual(elementC.Name, elementB.LinkedElements.First().Name);

        Assert.AreEqual(0, elementC.LinkedElements.Count());
        
        Assert.AreEqual(1, elementD.LinkedElements.Count());
        Assert.AreEqual(elementC.Name, elementD.LinkedElements.First().Name);
    }
    
    [Test]
    public void GetLinks()
    {
        var factory = new TestGraphFactory();
        var graph = factory.Create();

        graph.AddElement("elA", factory.A);
        graph.AddElement("elB", factory.B);
        graph.AddElement("elC", factory.C);
        graph.AddElement("elD", factory.D);

        var links = graph.Links;
        
        Assert.AreEqual(6, links.Count());
    }
}