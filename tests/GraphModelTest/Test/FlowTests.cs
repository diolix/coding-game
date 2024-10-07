using GraphModelTest.Mocks;
using PrimitiveNodeFactory = GraphModel.Node.NodeBuilder.Factories.PrimitiveNodeFactory;

namespace GraphModelTest.Test;

public class FlowTests : BaseNodeTests
{
    private readonly PrimitiveNodeFactory _primitiveNodeFactory = new();
    private readonly MockNodeFactory _mockNodeFactory = new();
    
    [Test]
    public void BasicFlow()
    {
        var start = _primitiveNodeFactory.CreateStart();
        
        bool hasBeenExecuted = false;
        var spy = _mockNodeFactory.CreateImpureInputFlowSpyNode(_ => hasBeenExecuted = true);
        
        AddEdge(start, 0, spy, 0);
        start.Execute();
        
        Assert.IsTrue(hasBeenExecuted);
    }
    
    [Test]
    public void OnFinishedExecution()
    {
        var start = _primitiveNodeFactory.CreateStart();
        bool onFinishedExecutionHasBeenCalled = false;
        start.OnFinishedExecution += () => onFinishedExecutionHasBeenCalled = true;
        start.Execute();
        
        Assert.IsTrue(onFinishedExecutionHasBeenCalled);
    }
}