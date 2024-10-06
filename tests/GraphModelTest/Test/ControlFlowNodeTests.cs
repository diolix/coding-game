using GraphModel.Node.NodeBuilder.Factories;
using GraphModelTest.Mocks;

namespace GraphModelTest.Test;

public class ControlFlowNodeTests : BaseNodeTests
{
    private readonly ControlFlowFactoryNode _controlFlowNodeTests = new();
    private readonly ConstantNodeFactory _constantNodeFactory = new();
    private readonly MockNodeFactory _mockNodeFactory = new();

    [Test]
    public void TestIfNodeConditionTrue()
    {
        var ifNode = _controlFlowNodeTests.CreateIf();
        var trueConstant = _constantNodeFactory.CreatePureTrueContant();
        var spyHasBeenExecuted = false;
        var spy = _mockNodeFactory.CreateImpureInputFlowSpyNode(_ => spyHasBeenExecuted = true);
        
        AddEdge(ifNode, 0, spy, 0);
        AddEdge(trueConstant, 0, ifNode, 1);
        ifNode.Execute();
        
        Assert.IsTrue(spyHasBeenExecuted);
    }
    
    [Test]
    public void TestIfNodeConditionFalse()
    {
        var ifNode = _controlFlowNodeTests.CreateIf();
        var falseConstant = _constantNodeFactory.CreatePureFalseContant();
        var spyHasBeenExecuted = false;
        var spy = _mockNodeFactory.CreateImpureInputFlowSpyNode(_ => spyHasBeenExecuted = true);
        
        AddEdge(ifNode, 1, spy, 0);
        AddEdge(falseConstant, 0, ifNode, 1);
        ifNode.Execute();
        
        Assert.IsTrue(spyHasBeenExecuted);
    }
}