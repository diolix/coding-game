using GraphModel.Edge;
using GraphModel.Values;
using static GraphModel.Node.Factories.ConstantFactory;
using static GraphModelTest.Mocks.MockNodeFactory;
using static NUnit.Framework.Assert;
namespace GraphModelTest.Test.Node;
public class BasicValue
{
    [Test]
    public void BasicImpureSetValue()
    {
        var helloWorldConstant = CreateImpureHelloWorldConstant();
        
        string mockStringInputValue = string.Empty;
        var mockInputNode = CreateInputValue(ValueTypeEnum.String, (_, input) =>
            mockStringInputValue = input.GetStringValue(""));
        
        bool mockExecuted = false;
        var mockExecutionNode = CreateFlowInput((_, _) =>
            mockExecuted = true);

        EdgeFactory.CreateEdge(helloWorldConstant, "value", mockInputNode, "");
        EdgeFactory.CreateEdge(helloWorldConstant, "", mockExecutionNode, "");
        
        helloWorldConstant.Execute();
        mockInputNode.Execute();
        
        That(mockStringInputValue, Is.EqualTo("Hello World"));
        IsTrue(mockExecuted);
    }
    
    [Test]
    public void BasicPureSetValue()
    {
        var helloWorldConstant = CreatePureHelloWorldConstant();
        
        string inputValue = string.Empty;
        var mockNode = CreateInputValue(ValueTypeEnum.String, (_, input) =>
            inputValue = input.GetStringValue(""));

        EdgeFactory.CreateEdge(helloWorldConstant, "", mockNode, "");
        
        mockNode.Execute();
        
        That(inputValue, Is.EqualTo("Hello World"));
    }
    
    [Test]
    public void MultiplePureOutputEdgesValueTest()
    {
        var helloWorldConstant = CreatePureHelloWorldConstant();
        
        string inputValue1 = string.Empty;
        var mockNode1 = CreateInputValue(ValueTypeEnum.String, (_, input) =>
            inputValue1 = input.GetStringValue(""));
        
        string inputValue2 = string.Empty;
        var mockNode2 = CreateInputValue(ValueTypeEnum.String, (_, input) =>
            inputValue2 = input.GetStringValue(""));
        
        EdgeFactory.CreateEdge(helloWorldConstant, "", mockNode1, "");
        EdgeFactory.CreateEdge(helloWorldConstant, "", mockNode2, "");
        
        helloWorldConstant.Execute();
        mockNode1.Execute();
        mockNode2.Execute();
        
        That(inputValue1, Is.EqualTo("Hello World"));
        That(inputValue2, Is.EqualTo("Hello World"));
    }
}