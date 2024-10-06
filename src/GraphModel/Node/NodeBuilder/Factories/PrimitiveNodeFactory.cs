using GraphModel.Node.BaseNodes;

namespace GraphModel.Node.NodeBuilder.Factories;

public class PrimitiveNodeFactory
{
    public INode CreateStart() => new NodeBuildable.Builder()
        .SetName("Start")
        .SetIsPure(true)
        .SetExecution(handlesExecution => handlesExecution.SafeExecute(0))
        .AddOutputFlow("")
        .Build();
}