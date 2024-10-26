using GraphModel.Edge;
using GraphModel.NewValueTypes;
using GraphModel.Node.Factories;
using GraphModelTest.Mocks;
using static NUnit.Framework.Assert;

namespace GraphModelTest.Test.Edge;

public class RemoveEdge : BaseEdgeTest
{
    [Test]
    public void FlowEdgeRemove()
    {
        var printHelloWorld = PrintFactory.CreatePrintHelloWorld();
        bool mockExecuted = false;
        var mockedNode = MockNodeFactory.CreateFlowInput((_,_) => { mockExecuted = true; });

        var edge = EdgeFactory.CreateEdge(printHelloWorld, "", mockedNode, "");
        edge.Remove();
        printHelloWorld.Execute();
        
        IsFalse(mockExecuted);
    }
    
    [Test]
    public void ValueEdgeRemove()
    {
        var helloWorldConstant = ConstantFactory.CreatePureHelloWorldConstant();
        var mockNode = MockNodeFactory.CreateStringInput((_, input) =>  input.GetStringValue(""));
        var edge = EdgeFactory.CreateEdge(helloWorldConstant, "", mockNode, "");
        
        edge.Remove();
        
        Throws<InvalidAccessToValueException>(() => mockNode.Execute());
    }
}