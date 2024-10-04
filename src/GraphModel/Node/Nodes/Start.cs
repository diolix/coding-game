using CodingGame.Script.Graph.Model.Node.BaseNodes;

namespace CodingGame.Script.Graph.Model.Node.Nodes;

public sealed class Start : PrimitiveNode
{
    public override string Name => "start";

    protected override void ConfigureHandle()
    {
        OutputsConstructor.AddFlow("start");
    }
    
    public override void Execute()
    {
        SafeExecute(0);
    }
}