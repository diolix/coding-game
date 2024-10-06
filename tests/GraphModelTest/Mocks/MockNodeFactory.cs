using GraphModel.Node.BaseNodes;
using GraphModel.Node.NodeBuilder;
using ValueType = GraphModel.ValueType;

namespace GraphModelTest.Mocks;

public class MockNodeFactory
{
    public INode CreateImpureInputFlowSpyNode(Action<HandlesExecution> callback)
    {
        return new NodeBuildable.Builder()
            .SetName("Spy")
            .SetIsPure(false)
            .AddInputFlow("")
            .SetExecution(callback)
            .Build();
    }
    
    public INode CreateStringInputMockNode(Action<HandlesExecution> callback)
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