using ControlFlowNodeFactory = GraphModel.Node.Factories.NewNode.ControlFlowNodeFactory;

namespace GraphModelTest.Test.Node;

public class ControlFlow : BaseNodeTest
{
    private readonly ControlFlowNodeFactory _controlFlowFactory = new();
    private readonly GraphModel.Node.Factories.NewNode.ConstantFactory _constantNodeFactory = new();

    [Test]
    public void IfConditionTrue()
    {
        var ifNode = _controlFlowFactory.CreateIf();
        var trueConstant = _constantNodeFactory.CreateTrueConstant();
        var spyHasBeenExecuted = false;
        var spy = MockNodeFactory.CreateNewFlowNodeMock((_, _) => spyHasBeenExecuted = true);

        EdgeFactory.CreateEdge(ifNode, "true", spy, "");
        EdgeFactory.CreateEdge(trueConstant, "", ifNode, "condition");
        ifNode.Execute();

        Assert.IsTrue(spyHasBeenExecuted);
    }

    [Test]
    public void IfConditionFalse()
    {
        var ifNode = _controlFlowFactory.CreateIf();
        var falseConstant = _constantNodeFactory.CreateFalseConstant();
        var spyHasBeenExecuted = false;
        var spy = MockNodeFactory.CreateNewFlowNodeMock((_, _) => spyHasBeenExecuted = true);

        EdgeFactory.CreateEdge(ifNode, "false", spy, "");
        EdgeFactory.CreateEdge(falseConstant, "", ifNode, "condition");
        ifNode.Execute();

        Assert.IsTrue(spyHasBeenExecuted);
    }

    [Test]
    public void WhileLoop()
    {
        var whileNode = _controlFlowFactory.CreateWhile();

        bool exitNodeExecuted = false;
        var mockExitNode = MockNodeFactory.CreateNewFlowNodeMock((_, _) => exitNodeExecuted = true);

        var bodyExecutedCount = 0;
        var mockBodyNode = MockNodeFactory.CreateNewFlowNodeMock((_,_) =>
        {
            bodyExecutedCount++;
        });

        var conditionNode = MockNodeFactory.CreateNewBoolOutputValueNodeMock((outputManager, _) =>
            outputManager.CacheValue("", bodyExecutedCount < 5));

        EdgeFactory.CreateEdge(conditionNode, "", whileNode, "condition");
        EdgeFactory.CreateEdge(whileNode, "body", mockBodyNode, "");
        EdgeFactory.CreateEdge(whileNode, "exit", mockExitNode, "");

        whileNode.Execute();

        Assert.IsTrue(exitNodeExecuted);
        Assert.That(bodyExecutedCount, Is.EqualTo(5));
    }
}