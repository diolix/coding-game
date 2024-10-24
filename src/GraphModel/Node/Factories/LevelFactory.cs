using ImpureNodeBuildable = GraphModel.Node.NodeBuilder.Impure.ImpureNodeBuildable;

namespace GraphModel.Node.Factories;

public class LevelFactory
{
    public static INode CreateStart() => new ImpureNodeBuildable.Builder()
        .SetName("Start")
        .AddOutputFlow("")
        .SetExecution((output, _) => output.Execute(""))
        .Build();
}