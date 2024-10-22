using GraphModel.Node.Factories;
using static NUnit.Framework.Assert;

namespace GraphModelTest.Test.Node;

public class BasicFlow : BaseNodeTest
{
    PrintFactory _printFactory = new PrintFactory();
    ConstantFactory _constantFactory = new ConstantFactory();

    [Test]
    public void BasicFlowTest()
    {
        var printHelloWorld = _printFactory.CreatePrintHelloWorld();
        bool mockExecuted = false;
        var mockedNode = MockNodeFactory.CreateNewFlowNodeMock((_,_) => { mockExecuted = true; });

        EdgeFactory.CreateEdge(printHelloWorld, "", mockedNode, "");
        printHelloWorld.Execute();
        
        IsTrue(mockExecuted);
    }

    [Test]
    public void BasicPureNodeTest()
    {
        var helloWorldConstant = _constantFactory.CreatePureHelloWorldConstant();
        var print = _printFactory.CreatePrint();
        EdgeFactory.CreateEdge(helloWorldConstant, "", print, "value");
        
        print.Execute();
    }
}