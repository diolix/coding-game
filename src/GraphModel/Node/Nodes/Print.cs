using CodingGame.Script.Graph.Model.Node.BaseNodes;

namespace GraphModel.Node.Nodes;

public class Print : PrimitiveNode
{
    public override string Name => "print";
    
    protected override void ConfigureHandle()
    {
        InputsConstructor.AddFlow("start");
        InputsConstructor.AddValue("string", ValueType.String);
        
        OutputsConstructor.AddFlow("end");
    }
    
    public override void Execute()
    {
        var toPrint = GetInputValue<string>(1).Value;
        Console.WriteLine(toPrint);
        SafeExecute(0);
    }

    
}