using GraphModel.Node.NodeBuilder.NewNode.Impure;

namespace GraphModel.Node.Factories;

public class LevelNodeFactory
{
    public static INode CreateStart() => new ImpureNodeBuildable.Builder()
        .SetName("Start")
        .AddOutputFlow("")
        .SetExecution((output, _) => output.Execute(""))
        .Build();
}