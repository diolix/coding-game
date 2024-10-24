using GraphModel.Edge;
using static GraphModel.Node.Factories.ConstantFactory;
using static GraphModel.Node.Factories.VariableNodeFactory;
using static GraphModel.Variable.VariableFactory;
using static NUnit.Framework.Assert;

namespace GraphModelTest.Test.Node;

public class Variable : BaseNodeTest
{

    [Test]
    public void GetVariable()
    {
        var helloWorldVariable = CreateVariable("HelloWorld", GraphModel.ValueType.String);
        helloWorldVariable.SafeSetValue("Hello World");

        var getVariable = CreateGetVariable(helloWorldVariable);

        string spyInput = string.Empty;
        var mockedNode =
            MockNodeFactory.CreateStringInput((_, input) => spyInput = input.GetStringValue(""));

        EdgeFactory.CreateEdge(getVariable, "value", mockedNode, "");

        mockedNode.Execute();

        That(spyInput, Is.EqualTo("Hello World"));
    }

    [Test]
    public void SetVariable()
    {
        var helloWorldVariable = CreateVariable("HelloWorld", GraphModel.ValueType.String);
        var setVariableNode = CreateSetVariable(helloWorldVariable);
        var helloWorldConstant = CreatePureHelloWorldConstant();
    
        EdgeFactory.CreateEdge(helloWorldConstant, "", setVariableNode, "new value");
    
        setVariableNode.Execute();
    
        That(helloWorldVariable.GetValue(), Is.EqualTo("Hello World"));
    }
    
    [Test]
    public void GetAndSetVariable()
    {
        var variable = CreateVariable("test", GraphModel.ValueType.String);
        var setNode = CreateSetVariable(variable);
        var getNode = CreateGetVariable(variable);
        var helloWorldConstant = CreatePureHelloWorldConstant();
    
        string spyInput = string.Empty;
        var mockedNode =
            MockNodeFactory.CreateStringInput((_, input) => spyInput = input.GetStringValue(""));
        
        EdgeFactory.CreateEdge(helloWorldConstant, "", setNode, "new value");
        EdgeFactory.CreateEdge(getNode, "value", mockedNode, "");
        
        setNode.Execute();
        mockedNode.Execute();
    
        That(spyInput, Is.EqualTo("Hello World"));
    }
}