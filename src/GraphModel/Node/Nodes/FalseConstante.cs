using CodingGame.Script.Graph.Model.Node.BaseNodes;
using ValueType = GraphModel.ValueType;

namespace CodingGame.Script.Graph.Model.Node.Nodes;

public class FalseConstante : PrimitiveNode
{
    public override string Name => "false constante";
    
    protected override void ConfigureHandle()
    {
        InputsConstructor.AddFlow("start");
        OutputsConstructor.AddFlow("end");
        OutputsConstructor.AddValue("value", ValueType.Bool);
    }
    
    public override void Execute()
    {
        SetOutputValue(1, false);
        SafeExecute(0);
    }
}