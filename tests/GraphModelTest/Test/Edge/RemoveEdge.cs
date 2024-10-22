using GraphModel.Node.Factories;
using GraphModel.Node.Input;
using static NUnit.Framework.Assert;

namespace GraphModelTest.Test.Edge;

public class RemoveEdge : BaseEdgeTest
{
    private readonly PrintFactory _printFactory = new PrintFactory();
    
    [Test]
    public void FlowEdgeRemove()
    {
        var printHelloWorld = _printFactory.CreatePrintHelloWorld();
        bool mockExecuted = false;
        var mockedNode = MockNodeFactory.CreateNewFlowNodeMock((_,_) => { mockExecuted = true; });

        var edge = EdgeFactory.CreateEdge(printHelloWorld, "", mockedNode, "");
        edge.Remove();
        printHelloWorld.Execute();
        
        IsFalse(mockExecuted);
    }
    
    [Test]
    public void ValueEdgeRemove()
    {
        var helloWorldConstant = new ConstantFactory().CreatePureHelloWorldConstant();
        var mockNode = MockNodeFactory.CreateNewStringValueInputNodeMock((_, input) => input.GetStringValue(""));
        
        var edge = EdgeFactory.CreateEdge(helloWorldConstant, "", mockNode, "");
        edge.Remove();
        
        Throws<InputManager.InputValueWithNoValueException>(() => mockNode.Execute());
    }
}