using GraphModel.Edge;
using GraphModel.Handle;
using GraphModel.Node.BaseNodes;
using GraphModel.Node.NodeBuilder;
using PrimitiveNodeFactory = GraphModel.Node.NodeBuilder.PrimitiveNodeFactory;

namespace GraphModelTest;

public class BasicNodeTests
{
    private readonly PrimitiveNodeFactory _primitiveNodeFactory = new();
    
    [Test]
    public void BasicFlow()
    {
        var start = _primitiveNodeFactory.CreateStart();
        bool hasBeenExecuted = false;
        var spy = CreateSpyNode(_ => hasBeenExecuted = true);
        
        AddEdge(start, 0, spy, 0);
        start.Execute();
        
        Assert.IsTrue(hasBeenExecuted);
    }
    
    private void AddEdge(INode from, int indexFrom, INode to, int indexTo)
    {
        from.Output.AddEdge(CreateEdge(from.Output.Handles[indexFrom], to.Input.Handles[indexTo]));
    }
    
    private IEdge CreateEdge(IHandle from, IHandle to)
    {
        return new EdgeModel(from, to);
    }

    private INode CreateSpyNode(Action<HandlesExecution> callback)
    {
        return new NodeBuildable.Builder()
            .SetName("Spy")
            .SetIsPure(false)
            .AddInputFlow("")
            .SetExecution(callback)
            .Build();
    }
}