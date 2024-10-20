using GraphModel.NewEdge;
using GraphModel.Node.Factories.NewNode;
using GraphModel.Node.Input;
using GraphModelTest.Mocks;
using static NUnit.Framework.Assert;

namespace GraphModelTest.Test.Edge;

public class RemoveEdge
{
    private readonly PrintFactory _printFactory = new PrintFactory();
    private readonly MockNodeFactory _mockNodeFactory = new MockNodeFactory();
    private readonly EdgeFactory _edgeFactory = new EdgeFactory();
    
    [Test]
    public void FlowEdgeRemove()
    {
        var printHelloWorld = _printFactory.CreatePrintHelloWorld();
        bool mockExecuted = false;
        var mockedNode = _mockNodeFactory.CreateNewFlowNodeMock((_,_) => { mockExecuted = true; });

        var edge = _edgeFactory.CreateEdge(printHelloWorld, "", mockedNode, "");
        edge.Remove();
        printHelloWorld.Execute();
        
        IsFalse(mockExecuted);
    }
    
    [Test]
    public void ValueEdgeRemove()
    {
        var helloWorldConstant = new ConstantFactory().CreatePureHelloWorldConstant();
        var mockNode = _mockNodeFactory.CreateNewStringValueInputNodeMock((_, input) => input.GetStringValue(""));
        
        var edge = _edgeFactory.CreateEdge(helloWorldConstant, "", mockNode, "");
        edge.Remove();
        
        Throws<NewInputManager.InputValueWithNoValueException>(() => mockNode.Execute());
    }
}