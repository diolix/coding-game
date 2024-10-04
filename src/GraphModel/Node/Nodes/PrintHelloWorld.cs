using CodingGame.Script.Graph.Model.Node.BaseNodes;

namespace GraphModel.Node.Nodes;

public sealed class PrintHelloWorld : PrimitiveNode
{
    public override string Name => "print hello world";
    
    protected override void ConfigureHandle()
    {
        InputsConstructor.AddFlow("start");
        OutputsConstructor.AddFlow("end");
    }
    
    public override void Execute()
    {
        Console.WriteLine("Hello World");
        SafeExecute(0);
    }
}