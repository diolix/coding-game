using GraphModel.Edge;
using GraphModel.Handle;
using GraphModel.NewEdge;
using GraphModel.Node;
using GraphModel.Node.Factories.NewNode;

namespace GraphModelTest.Test.EndToEnd;

public abstract class BaseNodeTests
{
    protected EdgeFactory EdgeFactory = new();
    protected PrintFactory PrintFactory = new();
    protected ConstantFactory ConstantFactory = new();
    
    protected IEdge AddEdge(INode from, int indexFrom, INode to, int indexTo)
    {
        var edge = CreateEdge(from.Output.Handles[indexFrom], to.Input.Handles[indexTo]);
        from.Output.AddEdge(edge);
        return edge;
    }
    
    private IEdge CreateEdge(IHandle from, IHandle to)
    {
        return new EdgeModel(from, to);
    }
}