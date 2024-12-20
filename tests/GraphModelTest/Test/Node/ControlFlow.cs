using GraphModel.Node.Factories;
using GraphModel.Values;
using static GraphModel.Edge.EdgeFactory;
using static GraphModel.Node.Factories.ControlFlowFactory;
using static GraphModelTest.Mocks.MockNodeFactory;
using static NUnit.Framework.Assert;

namespace GraphModelTest.Test.Node;

public class ControlFlow
{
    [Test]
    public void IfConditionTrue()
    {
        var ifNode = CreateIf();
        var trueConstant = ConstantFactory.CreateTrueConstant();
        var spyHasBeenExecuted = false;
        var spy = CreateFlowInput((_, _) => spyHasBeenExecuted = true);

        CreateEdge(ifNode, "true", spy, "");
        CreateEdge(trueConstant, "", ifNode, "condition");
        ifNode.Execute();

        IsTrue(spyHasBeenExecuted);
    }

    [Test]
    public void IfConditionFalse()
    {
        var ifNode = CreateIf();
        var falseConstant = ConstantFactory.CreateFalseConstant();
        var spyHasBeenExecuted = false;
        var spy = CreateFlowInput((_, _) => spyHasBeenExecuted = true);

        CreateEdge(ifNode, "false", spy, "");
        CreateEdge(falseConstant, "", ifNode, "condition");
        ifNode.Execute();

        IsTrue(spyHasBeenExecuted);
    }

    [Test]
    public void WhileLoop()
    {
        var whileNode = CreateWhile();

        bool exitNodeExecuted = false;
        var mockExitNode = CreateFlowInput((_, _) => exitNodeExecuted = true);

        var bodyExecutedCount = 0;
        var mockBodyNode = CreateFlowInput((_,_) =>
        {
            bodyExecutedCount++;
        });

        var conditionNode = CreateOutputValue(ValueTypeEnum.Bool, (outputManager, _) =>
            outputManager.CacheBool("", bodyExecutedCount < 5));

        CreateEdge(conditionNode, "", whileNode, "condition");
        CreateEdge(whileNode, "body", mockBodyNode, "");
        CreateEdge(whileNode, "exit", mockExitNode, "");

        whileNode.Execute();

        IsTrue(exitNodeExecuted);
        That(bodyExecutedCount, Is.EqualTo(5));
    }
}