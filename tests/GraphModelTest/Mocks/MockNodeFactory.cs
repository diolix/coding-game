using GraphModel.Node;
using GraphModel.Node.NodeBuilder.NewNode.Impure;
using GraphModel.Node.NodeBuilder.NewNode.Pure;
using ValueType = GraphModel.ValueType;

namespace GraphModelTest.Mocks;

public class MockNodeFactory
{
    public INode CreateFlowInput(ImpureNodeBuildable.Execution? callback)
    {
        return new ImpureNodeBuildable.Builder()
            .SetName("MockFlowInput")
            .AddInputFlow("")
            .SetExecution(callback ?? ((_, _) => {}))
            .Build();
    }
    
    public INode CreateFlowInputOutput(ImpureNodeBuildable.Execution? callback)
    {
        return new ImpureNodeBuildable.Builder()
            .SetName("MockFlowInputOutput")
            .AddInputFlow("")
            .AddOutputFlow("")
            .SetExecution(callback ?? ((_, _) => {}))
            .Build();
    }
    
    public INode CreateStringInput(PureNodeBuildable.Execution? callback)
    {
        return new PureNodeBuildable.Builder()
            .SetName("MockStringInput")
            .AddInputValue("", ValueType.String)
            .SetExecution(callback ?? ((_, _) => {}))
            .Build();
    }
    
    public INode CreatePureBoolOutput(PureNodeBuildable.Execution? callback)
    {
        return new PureNodeBuildable.Builder()
            .SetName("MockBoolOutput")
            .AddOutputValue("", ValueType.Bool)
            .SetExecution(callback ?? ((_, _) => {}))
            .Build();
    }
}