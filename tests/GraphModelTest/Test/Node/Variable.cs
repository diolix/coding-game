using GraphModel.Variable;
using static NUnit.Framework.Assert;
using VariableNodeFactory = GraphModel.Node.Factories.VariableNodeFactory;
using ConstantNodeFactory = GraphModel.Node.Factories.ConstantFactory;

namespace GraphModelTest.Test.Node;

public class Variable : BaseNodeTest
{
    private readonly VariableFactory _variableFactory = new();
    private readonly VariableNodeFactory _variableNodeFactory = new();
    private readonly ConstantNodeFactory _constantNodeFactory = new();

    [Test]
    public void GetVariable()
    {
        var helloWorldVariable = _variableFactory.CreateVariable("HelloWorld", GraphModel.ValueType.String);
        helloWorldVariable.SafeSetValue("Hello World");

        var getVariable = _variableNodeFactory.CreateGetVariable(helloWorldVariable);

        string spyInput = String.Empty;
        var mockedNode =
            MockNodeFactory.CreateStringInput((_, input) => spyInput = input.GetStringValue(""));

        EdgeFactory.CreateEdge(getVariable, "value", mockedNode, "");

        mockedNode.Execute();

        That(spyInput, Is.EqualTo("Hello World"));
    }

    [Test]
    public void SetVariable()
    {
        var helloWorldVariable = _variableFactory.CreateVariable("HelloWorld", GraphModel.ValueType.String);
        var setVariableNode = _variableNodeFactory.CreateSetVariable(helloWorldVariable);
        var helloWorldConstant = _constantNodeFactory.CreatePureHelloWorldConstant();
    
        EdgeFactory.CreateEdge(helloWorldConstant, "", setVariableNode, "new value");
    
        setVariableNode.Execute();
    
        That(helloWorldVariable.GetValue(), Is.EqualTo("Hello World"));
    }
    
    [Test]
    public void GetAndSetVariable()
    {
        var variable = _variableFactory.CreateVariable("test", GraphModel.ValueType.String);
        var setNode = _variableNodeFactory.CreateSetVariable(variable);
        var getNode = _variableNodeFactory.CreateGetVariable(variable);
        var helloWorldConstant = _constantNodeFactory.CreatePureHelloWorldConstant();
    
        string spyInput = String.Empty;
        var mockedNode =
            MockNodeFactory.CreateStringInput((_, input) => spyInput = input.GetStringValue(""));
        
        EdgeFactory.CreateEdge(helloWorldConstant, "", setNode, "new value");
        EdgeFactory.CreateEdge(getNode, "value", mockedNode, "");
        
        setNode.Execute();
        mockedNode.Execute();
    
        That(spyInput, Is.EqualTo("Hello World"));
    }
}