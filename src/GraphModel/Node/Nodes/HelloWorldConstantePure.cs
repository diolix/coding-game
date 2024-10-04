using CodingGame.Script.Graph.Model.Node.BaseNodes;
using ValueType = GraphModel.ValueType;

namespace CodingGame.Script.Graph.Model.Node.Nodes;

public class HelloWorldConstantePure : PrimitiveNode
{
    public override string Name => "Hello World Constante Pure";
    
    protected override void ConfigureHandle()
    {
        SetPure(true);
        OutputsConstructor.AddValue("Hello World", ValueType.String);
    }
    
    public override void Execute()
    {
        SetOutputValue(0, "Hello World");
    }
}