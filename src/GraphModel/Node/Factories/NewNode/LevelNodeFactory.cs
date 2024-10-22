using GraphModel.Node.NodeBuilder.NewNode.Impure;

namespace GraphModel.Node.Factories.NewNode;

public class LevelNodeFactory
{
    public INewNode CreateStart() => new ImpureNodeBuildable.Builder()
        .SetName("Start")
        .AddOutputFlow("")
        .SetExecution((output, _) => output.Execute(""))
        .Build();
}