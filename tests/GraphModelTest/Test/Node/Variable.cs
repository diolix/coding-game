using GraphModel.Values;
using GraphModel.Variable.TypeImplementation;
using static GraphModel.Edge.EdgeFactory;
using static GraphModel.Node.Factories.ConstantFactory;
using static GraphModel.Node.Factories.VariableNodeFactory;
using static GraphModelTest.Mocks.MockNodeFactory;
using static NUnit.Framework.Assert;

namespace GraphModelTest.Test.Node;

public class Variable
{

    [Test]
    public void GetVariable()
    {
        var helloWorldVariable = new BoolVariableModel("Test", true);

        var getVariable = CreateGetVariable(helloWorldVariable);

        bool spyInput = false;
        var mockedNode = CreateInputValue( ValueTypeEnum.Bool, (_, input) => spyInput = input.GetBoolValue(""));

        CreateEdge(getVariable, "value", mockedNode, "");

        mockedNode.Execute();

        That(spyInput, Is.EqualTo(true));
    }

    [Test]
    public void SetVariable()
    {
        var helloWorldVariable = new StringVariableModel("HelloWorld");
        var setVariableNode = CreateSetVariable(helloWorldVariable);
        var helloWorldConstant = CreatePureHelloWorldConstant();
    
        CreateEdge(helloWorldConstant, "", setVariableNode, "new value");
    
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
            CreateInputValue(ValueTypeEnum.String, (_, input) => spyInput = input.GetStringValue(""));
        
        CreateEdge(helloWorldConstant, "", setNode, "new value");
        CreateEdge(getNode, "value", mockedNode, "");
        
        setNode.Execute();
        mockedNode.Execute();
    
        That(spyInput, Is.EqualTo("Hello World"));
    }
}