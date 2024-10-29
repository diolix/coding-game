using GraphModel.Values;
using ImpureNodeBuildable = GraphModel.Node.NodeBuilder.Impure.ImpureNodeBuildable;

namespace GraphModel.Node.Factories;

public class PrintFactory
{
    public static INode CreatePrintHelloWorld() => new ImpureNodeBuildable.Builder()
        .SetName("print hello world")
        .AddInputFlow("")
        .AddOutputFlow("")
        .SetExecution((outputManager, _) =>
        {
            Console.WriteLine("Hello World");
            outputManager.Execute("");
        })
        .Build();
    
    public static INode CreatePrint() => new ImpureNodeBuildable.Builder()
        .SetName("print")
        .AddInputFlow("")
        .AddInputValueWithField("value", ValueTypeEnum.String)
        .AddOutputFlow("")
        .SetExecution((outputManager, inputManager) =>
        {
            Console.WriteLine(inputManager.GetStringValue("value"));
            outputManager.Execute("");
        })
        .Build();
}