using GraphModel.Node.NodeBuilder.NewNode;

namespace GraphModel.Node.Factories.NewNode;

public class PrintFactory
{
    public INewNode CreatePrintHelloWorld() => new NewNodeBuildable.Builder()
        .SetName("PrintHelloWorld")
        .AddInputFlow("")
        .AddOutputFlow("")
        .SetExecution(execution =>
        {
            Console.WriteLine("Hello World");
            execution.SafeExecute("");
        })
        .Build();
}