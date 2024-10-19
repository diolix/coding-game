using GraphModel.Node.Factories.NewNode;
using static NUnit.Framework.Assert;

namespace GraphModelTest.Test.NewNode;

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
        var helloWorldConstant = _constantFactory.CreateHelloWorldConstant();
        var print = _printFactory.CreatePrint();
        EdgeFactory.CreateEdge(helloWorldConstant, "", print, "value");
        
        print.Execute();
    }
}