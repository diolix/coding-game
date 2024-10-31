using GraphModel.Values;
using ImpureNodeBuildable = GraphModel.Node.NodeBuilder.Impure.ImpureNodeBuildable;

namespace GraphModel.Node.Factories;

public static class PrintFactory
{
    public static INode CreatePrintObj() => new ImpureNodeBuildable.Builder()
        .SetName("Print object")
        .AddInputFlow("")
        .AddInputValue("value", ValueTypeEnum.Object)
        .AddOutputFlow("")
        .SetExecution((outputManager, inputManager) =>
        {
            Console.WriteLine(inputManager.GetObjectValue("value"));
            outputManager.Execute("");
        })
        .Build();
    
    public static INode CreatePrintString() => new ImpureNodeBuildable.Builder()
        .SetName("Print string")
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