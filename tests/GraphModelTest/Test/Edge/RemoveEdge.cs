using GraphModel.Node.Factories;
using GraphModel.Values;
using static GraphModel.Edge.EdgeFactory;
using static GraphModel.Node.Factories.PrintFactory;
using static GraphModelTest.Mocks.MockNodeFactory;
using static NUnit.Framework.Assert;

namespace GraphModelTest.Test.Edge;

public class RemoveEdge
{
    [Test]
    public void FlowEdgeRemove()
    {
        var printHelloWorld = CreateFlowInputOutput();
        bool mockExecuted = false;
        var mockedNode = CreateFlowInput((_,_) => { mockExecuted = true; });

        var edge = CreateEdge(printHelloWorld, "", mockedNode, "");
        edge.Remove();
        printHelloWorld.Execute();
        
        IsFalse(mockExecuted);
    }
    
    [Test]
    public void ValueEdgeRemove()
    {
        var helloWorldConstant = ConstantFactory.CreatePureHelloWorldConstant();
        var mockNode = CreateInputValue(ValueTypeEnum.String, (_, input) =>  input.GetStringValue(""));
        var edge = CreateEdge(helloWorldConstant, "", mockNode, "");
        
        edge.Remove();
        
        Throws<InvalidAccessToValueException>(() => mockNode.Execute());
    }
}