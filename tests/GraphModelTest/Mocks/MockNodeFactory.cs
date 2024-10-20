using GraphModel.Node;
using GraphModel.Node.NodeBuilder;
using GraphModel.Node.NodeBuilder.NewNode.Impure;
using GraphModel.Node.NodeBuilder.NewNode.Pure;
using ValueType = GraphModel.ValueType;

namespace GraphModelTest.Mocks;

public class MockNodeFactory
{
    public INewNode CreateNewFlowNodeMock(ImpureNodeBuildable.Execution callback)
    {
        return new ImpureNodeBuildable.Builder()
            .SetName("Mock")
            .AddInputFlow("")
            .SetExecution(callback)
            .Build();
    }
    
    public INewNode CreateNewStringValueInputNodeMock(PureNodeBuildable.Execution callback)
    {
        return new PureNodeBuildable.Builder()
            .SetName("Mock")
            .AddInputValue("", ValueType.String)
            .SetExecution(callback)
            .Build();
    }
    
    public INewNode CreateNewBoolOutputValueNodeMock(PureNodeBuildable.Execution callback)
    {
        return new PureNodeBuildable.Builder()
            .SetName("Mock")
            .AddOutputValue("", ValueType.Bool)
            .SetExecution(callback)
            .Build();
    }
}