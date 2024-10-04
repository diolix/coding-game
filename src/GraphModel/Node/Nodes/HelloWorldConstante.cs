using CodingGame.Script.Graph.Model.Node.BaseNodes;
using ValueType = GraphModel.ValueType;

namespace CodingGame.Script.Graph.Model.Node.Nodes;

public sealed class HelloWorldConstante : PrimitiveNode
{
    public override string Name => "hello world constante";

    protected override void ConfigureHandle()
    {
        InputsConstructor.AddFlow("start");
        OutputsConstructor.AddFlow("end");
        OutputsConstructor.AddValue("string", ValueType.String);
    }
    
    public override void Execute()
    {
        SetOutputValue(1, "Hello World");
        SafeExecute(0);
    }
}