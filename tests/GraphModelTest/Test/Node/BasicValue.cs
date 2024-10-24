using GraphModel.Edge;
using GraphModel.Node.Factories;
using static NUnit.Framework.Assert;
namespace GraphModelTest.Test.Node;
public class BasicValue : BaseNodeTest
{
    [Test]
    public void BasicImpureSetValue()
    {
        var helloWorldConstant = ConstantFactory.CreateImpureHelloWorldConstant();
        
        string mockStringInputValue = string.Empty;
        var mockInputNode = MockNodeFactory.CreateStringInput((_, input) =>
            mockStringInputValue = input.GetStringValue(""));
        
        bool mockExecuted = false;
        var mockExecutionNode = MockNodeFactory.CreateFlowInput((_, _) =>
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
        var helloWorldConstant = ConstantFactory.CreatePureHelloWorldConstant();
        
        string inputValue = string.Empty;
        var mockNode = MockNodeFactory.CreateStringInput((_, input) =>
            inputValue = input.GetStringValue(""));

        EdgeFactory.CreateEdge(helloWorldConstant, "", mockNode, "");
        
        mockNode.Execute();
        
        That(inputValue, Is.EqualTo("Hello World"));
    }
    
    [Test]
    public void MultiplePureOutputEdgesValueTest()
    {
        var helloWorldConstant = ConstantFactory.CreatePureHelloWorldConstant();
        
        string inputValue1 = string.Empty;
        var mockNode1 = MockNodeFactory.CreateStringInput((_, input) =>
            inputValue1 = input.GetStringValue(""));
        
        string inputValue2 = string.Empty;
        var mockNode2 = MockNodeFactory.CreateStringInput((_, input) =>
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