using GraphModel.Edge;
using GraphModel.Handle;
using GraphModel.Node;

namespace GraphModelTest.Test;

public abstract class BaseNodeTests
{
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