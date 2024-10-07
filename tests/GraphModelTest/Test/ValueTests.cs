using GraphModel.Node;
using GraphModel.Node.NodeBuilder;
using GraphModel.Node.NodeBuilder.Factories;
using GraphModelTest.Mocks;
using ValueType = GraphModel.ValueType;

namespace GraphModelTest.Test;

public class ValueTests : BaseNodeTests
{
    private readonly ConstantNodeFactory _constantNodeFactory = new();
    private readonly MockNodeFactory _mockNodeFactory = new();
    
    [Test]
    public void BasicImpureSetValue()
    {
        var helloWorldConstant = _constantNodeFactory.CreateImpureHelloWorldContant();
        string input = string.Empty;
        var spy = _mockNodeFactory.CreateStringInputMockNode(execution =>
        {
            input = execution.GetStringInputValue(1).Value;
        });
        
        AddEdge(helloWorldConstant, 0, spy, 0);
        AddEdge(helloWorldConstant, 1, spy, 1);
        
        helloWorldConstant.Execute();
        Assert.IsFalse(string.IsNullOrEmpty(input));
    }
    
    [Test]
    public void BasicPureSetValue()
    {
        var helloWorldConstant = _constantNodeFactory.CreatePureHelloWorldContant();
        string input = string.Empty;
        var spy = _mockNodeFactory.CreateStringInputMockNode(execution =>
        {
            input = execution.GetStringInputValue(1).Value;
        });
        
        AddEdge(helloWorldConstant, 0, spy, 1);
        
        spy.Execute();
        Assert.IsFalse(string.IsNullOrEmpty(input));
    }

    [Test]
    public void MultipleOutputEdgesValueTest()
    {
        var helloWorldConstant = _constantNodeFactory.CreateImpureHelloWorldContant();
        string input1 = string.Empty;
        var spy1 = _mockNodeFactory.CreateStringInputMockNode(execution =>
        {
            input1 = execution.GetStringInputValue(1).Value;
        });
        string input2 = string.Empty;
        var spy2 = _mockNodeFactory.CreateStringInputMockNode(execution =>
        {
            input2 = execution.GetStringInputValue(1).Value;
        });
        
        AddEdge(helloWorldConstant, 1, spy1, 1);
        AddEdge(helloWorldConstant, 1, spy2, 1);
        
        helloWorldConstant.Execute();
        spy1.Execute();
        spy2.Execute();
        
        Assert.IsFalse(string.IsNullOrEmpty(input1));
        Assert.IsFalse(string.IsNullOrEmpty(input2));
    }
    
    private INode CreateStringInputSpyNode(Action<HandlesExecution> callback)
    {
        return new NodeBuildable.Builder()
            .SetName("Spy")
            .SetIsPure(false)
            .AddInputFlow("")
            .AddInputValue("Value", ValueType.String)
            .SetExecution(execution =>
            {
                callback(execution);
                execution.SafeExecute(0);
            })
            .Build();
    }
    
    
}