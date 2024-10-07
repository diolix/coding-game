namespace GraphModel.Node.NodeBuilder.Factories;

public class LevelNodeFactory
{
    public INode CreateStart() => new NodeBuildable.Builder()
        .SetName("Start")
        .SetIsPure(true)
        .SetExecution(handlesExecution => handlesExecution.SafeExecute(0))
        .AddOutputFlow("")
        .Build();
}