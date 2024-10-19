using GraphModel.Node;
using GraphModel.Node.NodeBuilder;
using GraphModel.Node.NodeBuilder.NewNode;
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
    
    public INewNode CreateNewNodeMockNode(Action<NewHandlesExecution> callback)
    {
        return new NewNodeBuildable.Builder()
            .SetName("Spy")
            .AddInputFlow("")
            .SetExecution(callback)
            .Build();
    }
}