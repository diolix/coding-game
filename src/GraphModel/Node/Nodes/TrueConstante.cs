using CodingGame.Script.Graph.Model.Node.BaseNodes;
using ValueType = GraphModel.ValueType;

namespace CodingGame.Script.Graph.Model.Node.Nodes;

public class TrueConstante : PrimitiveNode
{
    public override string Name => "true constante";
    
    protected override void ConfigureHandle()
    {
        InputsConstructor.AddFlow("start");
        OutputsConstructor.AddFlow("end");
        OutputsConstructor.AddValue("value", ValueType.Bool);
    }
    
    public override void Execute()
    {
        SetOutputValue(1, true);
        SafeExecute(0);
    }

}