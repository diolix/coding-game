using GraphModel.Node.BaseNodes;
using GraphModel.Node.NodeBuilder;
using GraphModel.Node.NodeBuilder.Factories;
using ValueType = GraphModel.ValueType;

namespace GraphModelTest;

public class ValueTests : BaseNodeTests
{
    private readonly ConstantNodeFactory _constantNodeFactory = new();
    
    [Test]
    public void BasicImpureSetValue()
    {
        var helloWorldConstant = _constantNodeFactory.CreateImpureHelloWorldContant();
        string input = string.Empty;
        var spy = CreateStringInputSpyNode(execution =>
        {
            input = execution.GetInputValue<string>(1).Value;
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
        var spy = CreateStringInputSpyNode(execution =>
        {
            input = execution.GetInputValue<string>(1).Value;
        });
        
        AddEdge(helloWorldConstant, 0, spy, 1);
        
        spy.Execute();
        Assert.IsFalse(string.IsNullOrEmpty(input));
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