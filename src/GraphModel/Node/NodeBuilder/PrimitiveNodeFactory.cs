using GraphModel.Node.BaseNodes;

namespace GraphModel.Node.NodeBuilder;

public class PrimitiveNodeFactory
{
    public INode CreateStart() => new NodeBuildable.Builder()
        .SetName("Start")
        .SetIsPure(true)
        .SetExecution(handlesExecution => handlesExecution.SafeExecute(0))
        .AddOutputFlow("")
        .Build();

    public INode CreatePrintHelloWorld() => new NodeBuildable.Builder()
        .SetName("Print Hello World")
        .SetIsPure(true)
        .SetExecution(handlesExecution =>
        {
            Console.WriteLine("Hello World");
            handlesExecution.SafeExecute(0);
        })
        .AddOutputFlow("")
        .AddInputFlow("")
        .Build();
}