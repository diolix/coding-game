using GraphModel.Node.NodeBuilder.Factories;
using GraphModelTest.Mocks;
using GraphModelTest.Test.EndToEnd;

namespace GraphModelTest.Test;

public class FlowTests : BaseNodeTests
{
    private readonly LevelNodeFactory _levelNodeFactory = new();
    private readonly MockNodeFactory _mockNodeFactory = new();
    
    [Test]
    public void BasicFlow()
    {
        var start = _levelNodeFactory.CreateStart();
        
        bool hasBeenExecuted = false;
        var spy = _mockNodeFactory.CreateImpureInputFlowSpyNode(_ => hasBeenExecuted = true);
        
        AddEdge(start, 0, spy, 0);
        start.Execute();
        
        Assert.IsTrue(hasBeenExecuted);
    }
    
    [Test]
    public void OnFinishedExecution()
    {
        var start = _levelNodeFactory.CreateStart();
        bool onFinishedExecutionHasBeenCalled = false;
        start.OnFinishedExecution += () => onFinishedExecutionHasBeenCalled = true;
        start.Execute();
        
        Assert.IsTrue(onFinishedExecutionHasBeenCalled);
    }
}