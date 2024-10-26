using GraphModel.Edge;
using GraphModel.Variable;
using GraphModel.Variable.TypeImplementation;
using GraphModelTest.Mocks;
using static GraphModel.Node.Factories.ConstantFactory;
using static GraphModel.Node.Factories.VariableNodeFactory;
using static NUnit.Framework.Assert;

namespace GraphModelTest.Test.Node;

public class Variable : BaseNodeTest
{

    [Test]
    public void GetVariable()
    {
        var helloWorldVariable = new StringVariableModel("HelloWorld", "Hello World");

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
        var helloWorldVariable = new StringVariableModel("HelloWorld");
        var setVariableNode = CreateSetVariable(helloWorldVariable);
        var helloWorldConstant = CreatePureHelloWorldConstant();
    
        EdgeFactory.CreateEdge(helloWorldConstant, "", setVariableNode, "new value");
    
        setVariableNode.Execute();
    
        That(helloWorldVariable.Value.GetValue(), Is.EqualTo("Hello World"));
    }
    
    [Test]
    public void GetAndSetVariable()
    {
        var variable = new StringVariableModel("test");
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