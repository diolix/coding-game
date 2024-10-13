using GraphModel.Node.NodeBuilder.Factories;
using GraphModelTest.Mocks;
using GraphModelTest.Test.EndToEnd;

namespace GraphModelTest.Test;

public class ControlFlowNodeTests : BaseNodeTests
{
    private readonly ControlFlowNodeFactory _controlFlowNodeTests = new();
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

    [Test]
    public void TestWhileNode()
    {
        var whileNode = _controlFlowNodeTests.CreateWhile();
        var trueConstant = _constantNodeFactory.CreatePureTrueContant();
        var falseConstant = _constantNodeFactory.CreatePureFalseContant();
        
        bool exitNodeExecuted = false;
        var mockExitNode = _mockNodeFactory.CreateImpureInputFlowSpyNode(_ => exitNodeExecuted = true);
        
        var trueConstantWhileEdge = AddEdge(trueConstant, 0, whileNode, 1);
        
        var bodyExecutedCount = 0;
        var mockBodyNode = _mockNodeFactory.CreateImpureInputFlowSpyNode(_ =>
        {
            if (bodyExecutedCount++ == 5)
            {
                trueConstant.Output.RemoveEdge(trueConstantWhileEdge);
                AddEdge(falseConstant, 0, whileNode, 1);
            }
        });
        
        AddEdge(whileNode, 1, mockBodyNode, 0);
        AddEdge(whileNode, 0, mockExitNode, 0);
        
        whileNode.Execute();
        
        Assert.IsTrue(exitNodeExecuted);
        Assert.That(bodyExecutedCount, Is.EqualTo(6));
    }
}