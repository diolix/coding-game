using GraphModel.Node.BaseNodes;
using GraphModel.Node.NodeBuilder;
using PrimitiveNodeFactory = GraphModel.Node.NodeBuilder.Factories.PrimitiveNodeFactory;

namespace GraphModelTest;

public class FlowTests : BaseNodeTests
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