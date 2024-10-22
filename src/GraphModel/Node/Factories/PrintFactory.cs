using GraphModel.Node.NodeBuilder.NewNode.Impure;

namespace GraphModel.Node.Factories;

public class PrintFactory
{
    public INewNode CreatePrintHelloWorld() => new ImpureNodeBuildable.Builder()
        .SetName("print hello world")
        .AddInputFlow("")
        .AddOutputFlow("")
        .SetExecution((outputManager, _) =>
        {
            Console.WriteLine("Hello World");
            outputManager.Execute("");
        })
        .Build();
    
    public INewNode CreatePrint() => new ImpureNodeBuildable.Builder()
        .SetName("print")
        .AddInputFlow("")
        .AddInputValue("value", ValueType.String)
        .AddOutputFlow("")
        .SetExecution((outputManager, inputManager) =>
        {
            Console.WriteLine(inputManager.GetValue("value").Value);
            outputManager.Execute("");
        })
        .Build();
}