using CodingGame.Script.Graph.Model.Node.BaseNodes;
using ValueType = GraphModel.ValueType;

namespace CodingGame.Script.Graph.Model.Node.Nodes;

public class If : PrimitiveNode
{
    public override string Name => "If";
    
    protected override void ConfigureHandle()
    {
        InputsConstructor.AddFlow("start");
        InputsConstructor.AddValue("condition", ValueType.Bool);
        
        OutputsConstructor.AddFlow("true");
        OutputsConstructor.AddFlow("false");
    }
    
    public override void Execute()
    {
        if(GetInputValue<bool>(1).Value) SafeExecute(0);
        else SafeExecute(1);
    }
}