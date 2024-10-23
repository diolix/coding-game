using GraphModel.Node.NodeBuilder.NewNode.Impure;

namespace GraphModel.Node.Factories;

public class PrintFactory
{
    public INode CreatePrintHelloWorld() => new ImpureNodeBuildable.Builder()
        .SetName("print hello world")
        .AddInputFlow("")
        .AddOutputFlow("")
        .SetExecution((outputManager, _) =>
        {
            Console.WriteLine("Hello World");
            outputManager.Execute("");
        })
        .Build();
    
    public INode CreatePrint() => new ImpureNodeBuildable.Builder()
        .SetName("print")
        .AddInputFlow("")
        .AddInputValue("value", ValueType.String)
        .AddOutputFlow("")
        .SetExecution((outputManager, inputManager) =>
        {
            Console.WriteLine(inputManager.GetStringValue("value"));
            outputManager.Execute("");
        })
        .Build();
}