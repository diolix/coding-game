using GraphModel.Node.NodeBuilder.Factories;
using GraphModel.Variable;
using GraphModelTest.Mocks;
using ValueType = GraphModel.ValueType;

namespace GraphModelTest.Test;

public class VariableNodeTests : BaseNodeTests
{
    private readonly VariableFactory _variableFactory = new();
    private readonly VariableNodeFactory _variableNodeFactory = new();
    private readonly ConstantNodeFactory _constantNodeFactory = new();
    private readonly MockNodeFactory _mockNodeFactory = new();

    [Test]
    public void GetVariable()
    {
        var helloWorldVariable = _variableFactory.CreateVariable("HelloWorld", ValueType.String);
        helloWorldVariable.SafeSetValue("Hello World");

        var getVariable = _variableNodeFactory.CreateGetVariable(helloWorldVariable);

        string spyInput = String.Empty;
        var mockedNode = _mockNodeFactory.CreateStringInputMockNode(execution =>
            spyInput = execution.GetStringInputValue(0).Value);

        AddEdge(getVariable, 0, mockedNode, 0);

        mockedNode.Execute();

        Assert.That(spyInput, Is.EqualTo("Hello World"));
    }

    [Test]
    public void SetVariable()
    {
        var helloWorldVariable = _variableFactory.CreateVariable("HelloWorld", ValueType.String);
        var setVariableNode = _variableNodeFactory.CreateSetVariable(helloWorldVariable);
        var helloWorldConstant = _constantNodeFactory.CreatePureHelloWorldContant();

        AddEdge(helloWorldConstant, 0, setVariableNode, 1);

        setVariableNode.Execute();

        Assert.That(helloWorldVariable.GetValue(), Is.EqualTo("Hello World"));
    }

    [Test]
    public void GetAndSetVariable()
    {
        var variable = _variableFactory.CreateVariable("test", ValueType.String);
        var setNode = _variableNodeFactory.CreateSetVariable(variable);
        var getNode = _variableNodeFactory.CreateGetVariable(variable);
        var helloWorldConstant = _constantNodeFactory.CreatePureHelloWorldContant();
        
        string inputValueMockNode = string.Empty;
        var mockNodeInput = _mockNodeFactory.CreateStringInputMockNode(execution =>
                inputValueMockNode = execution.GetStringInputValue(1).Value
            );
        
        AddEdge(helloWorldConstant, 0, setNode, 1);
        AddEdge(setNode, 0, mockNodeInput, 0);
        AddEdge(getNode, 0, mockNodeInput, 1);
        
        setNode.Execute();
        
        Assert.That(inputValueMockNode, Is.EqualTo("Hello World"));
    }
}