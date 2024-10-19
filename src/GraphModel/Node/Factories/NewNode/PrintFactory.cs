using GraphModel.Node.NodeBuilder.NewNode.Impure;

namespace GraphModel.Node.Factories.NewNode;

public class PrintFactory
{
    public INewNode CreatePrintHelloWorld() => new ImpureNodeBuildable.ImpureNodeBuilder()
        .SetName("PrintHelloWorld")
        .AddInputFlow("")
        .AddOutputFlow("")
        .SetExecution((outputManager, _) =>
        {
            Console.WriteLine("Hello World");
            outputManager.Execute("");
        })
        .Build();
    
    public INewNode CreatePrint() => new ImpureNodeBuildable.ImpureNodeBuilder()
        .SetName("Print")
        .AddInputFlow("")
        .AddInputValue("Value", ValueType.String)
        .AddOutputFlow("")
        .SetExecution((outputManager, inputManager) =>
        {
            Console.WriteLine(inputManager.GetValue("Value").Value);
            outputManager.Execute("");
        })
        .Build();
}