using GraphModel.NewEdge;
using GraphModel.Node.Factories.NewNode;
using GraphModelTest.Mocks;
using static NUnit.Framework.Assert;

namespace GraphModelTest.Test.NewNode;

public class BasicFlow
{
    PrintFactory _printFactory = new PrintFactory();
    ConstantFactory _constantFactory = new ConstantFactory();
    MockNodeFactory _mockNodeFactory = new MockNodeFactory();
    EdgeFactory _edgeFactory = new EdgeFactory();

    [Test]
    public void BasicFlowTest()
    {
        var printHelloWorld = _printFactory.CreatePrintHelloWorld();
        bool mockExecuted = false;
        var mockedNode = _mockNodeFactory.CreateNewNodeMockNode((_,_) => { mockExecuted = true; });

        _edgeFactory.CreateEdge(printHelloWorld.OutputHandles[0], mockedNode.InputHandles[0]);
        printHelloWorld.Execute();
        
        IsTrue(mockExecuted);
    }

    [Test]
    public void BasicPureNodeTest()
    {
        var helloWorldConstant = _constantFactory.CreateHelloWorldConstant();
        var print = _printFactory.CreatePrint();
        _edgeFactory.CreateEdge(helloWorldConstant.OutputHandles[0], print.InputHandles[1]);
        
        print.Execute();
    }
}