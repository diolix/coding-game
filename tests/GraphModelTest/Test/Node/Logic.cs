using GraphModel.Values;
using static GraphModel.Edge.EdgeFactory;
using static GraphModel.Node.Factories.ConstantFactory;
using static GraphModel.Node.Factories.LogicFactory;
using static GraphModelTest.Mocks.MockNodeFactory;
using static NUnit.Framework.Assert;

namespace GraphModelTest.Test.Node;

public class Logic
{
    [Test]
    public void AndTrue()
    {
        var andNode = CreateAnd();
        var trueConstant = CreateTrueConstant();
        var falseConstant = CreateFalseConstant();
        
        var mockedNodeValue = true;
        var mockedNode = CreateInputValue(ValueTypeEnum.Bool, (_, input) =>
        {
            mockedNodeValue = input.GetBoolValue("");
        });
        
        CreateEdge(trueConstant, "", andNode, "a");
        CreateEdge(falseConstant, "", andNode, "b");
        CreateEdge(andNode, "result", mockedNode, "");
        
        mockedNode.Execute();
        IsFalse(mockedNodeValue);
    }

    [Test]
    public void AndFalse()
    {
        var andNode = CreateAnd();
        var trueConstant = CreateTrueConstant();
        var trueConstant2 = CreateTrueConstant();
        
        var mockedNodeValue = false;
        var mockedNode = CreateInputValue(ValueTypeEnum.Bool,(_, input) =>
        {
            mockedNodeValue = input.GetBoolValue("");
        });
        
        CreateEdge(trueConstant, "", andNode, "a");
        CreateEdge(trueConstant2, "", andNode, "b");
        CreateEdge(andNode, "result", mockedNode, "");
        
        mockedNode.Execute();
        IsTrue(mockedNodeValue);
    }

    [Test]
    public void OrFalse()
    {
        var orNode = CreateOr();
        var falseConstant = CreateFalseConstant();
        var falseConstant2 = CreateFalseConstant();
        
        var mockedNodeValue = true;
        var mockedNode = CreateInputValue(ValueTypeEnum.Bool,(_, input) =>
        {
            mockedNodeValue = input.GetBoolValue("");
        });
        
        CreateEdge(falseConstant, "", orNode, "a");
        CreateEdge(falseConstant2, "", orNode, "b");
        CreateEdge(orNode, "result", mockedNode, "");
        
        mockedNode.Execute();
        IsFalse(mockedNodeValue);
    }
    
    [Test]
    public void OrTrue()
    {
        var orNode = CreateOr();
        var falseConstant = CreateFalseConstant();
        var trueConstant = CreateTrueConstant();
        
        var mockedNodeValue = false;
        var mockedNode = CreateInputValue(ValueTypeEnum.Bool,(_, input) =>
        {
            mockedNodeValue = input.GetBoolValue("");
        });
        
        CreateEdge(falseConstant, "", orNode, "a");
        CreateEdge(trueConstant, "", orNode, "b");
        CreateEdge(orNode, "result", mockedNode, "");
        
        mockedNode.Execute();
        IsTrue(mockedNodeValue);
    }

    [Test]
    public void Not()
    {
        var notNode = CreateNot();
        var falseConstant = CreateFalseConstant();
        
        var mockedNodeValue = false;
        var mockedNode = CreateInputValue(ValueTypeEnum.Bool,(_, input) =>
        {
            mockedNodeValue = input.GetBoolValue("");
        });
        
        CreateEdge(falseConstant, "", notNode, "a");
        CreateEdge(notNode, "result", mockedNode, "");
        
        mockedNode.Execute();
        IsTrue(mockedNodeValue);
    }
}