using GraphModel.Edge;
using GraphModel.Handle;
using GraphModel.Node.BaseNodes;

namespace GraphModelTest;

public abstract class BaseNodeTests
{
    protected void AddEdge(INode from, int indexFrom, INode to, int indexTo)
    {
        from.Output.AddEdge(CreateEdge(from.Output.Handles[indexFrom], to.Input.Handles[indexTo]));
    }
    
    private IEdge CreateEdge(IHandle from, IHandle to)
    {
        return new EdgeModel(from, to);
    }
}