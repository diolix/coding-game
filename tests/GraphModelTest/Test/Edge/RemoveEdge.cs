using GraphModel.Edge;
using GraphModel.Node.Factories;
using GraphModel.Values;
using static GraphModelTest.Mocks.MockNodeFactory;
using static NUnit.Framework.Assert;

namespace GraphModelTest.Test.Edge;

public class RemoveEdge
{
    [Test]
    public void FlowEdgeRemove()
    {
        var printHelloWorld = PrintFactory.CreatePrintHelloWorld();
        bool mockExecuted = false;
        var mockedNode = CreateFlowInput((_,_) => { mockExecuted = true; });

        var edge = EdgeFactory.CreateEdge(printHelloWorld, "", mockedNode, "");
        edge.Remove();
        printHelloWorld.Execute();
        
        IsFalse(mockExecuted);
    }
    
    [Test]
    public void ValueEdgeRemove()
    {
        var helloWorldConstant = ConstantFactory.CreatePureHelloWorldConstant();
        var mockNode = CreateInputValue(ValueTypeEnum.String, (_, input) =>  input.GetStringValue(""));
        var edge = EdgeFactory.CreateEdge(helloWorldConstant, "", mockNode, "");
        
        edge.Remove();
        
        Throws<InvalidAccessToValueException>(() => mockNode.Execute());
    }
}