using ControlFlowNodeFactory = GraphModel.Node.Factories.NewNode.ControlFlowNodeFactory;

namespace GraphModelTest.Test.NewNode;

public class ControlFlow : BaseNodeTest
{
    private ControlFlowNodeFactory _controlFlowFactory = new();
    private GraphModel.Node.Factories.NewNode.ConstantFactory _constantNodeFactory = new();
    [Test]
    public void TestIfNodeConditionTrue()
    {
        var ifNode = _controlFlowFactory.CreateIf();
        var trueConstant = _constantNodeFactory.CreateTrueConstant();
        var spyHasBeenExecuted = false;
        var spy = MockNodeFactory.CreateNewFlowNodeMock((_,_) => spyHasBeenExecuted = true);
        
        EdgeFactory.CreateEdge(ifNode, "true", spy, "");
        EdgeFactory.CreateEdge(trueConstant, "", ifNode, "condition");
        ifNode.Execute();
        
        Assert.IsTrue(spyHasBeenExecuted);
    }
}