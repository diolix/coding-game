using GraphModel.Node.BaseNodes;

namespace GraphModel.Node.NodeBuilder.Factories.Print;

public class PrintNodeFactory
{
    private IConsole _console;
    
    public PrintNodeFactory(IConsole console)
    {
        _console = console;
    }
    
    public INode CreatePrint() => new NodeBuildable.Builder()
        .SetName("Print")
        .SetIsPure(false)
        
        .AddInputFlow("")
        .AddInputValue("Value", ValueType.String)
        
        .AddOutputFlow("")
        
        .SetExecution(execution =>
        {
            _console.WriteLine(execution.GetStringInputValue(1).Value);
            execution.SafeExecute(0);
        }).Build();
    
    public INode CreatePrintHelloWorld() => new NodeBuildable.Builder()
        .SetName("Print Hello World")
        .SetIsPure(true)
        
        .AddInputFlow("")
        
        .AddOutputFlow("")
        
        .SetExecution(handlesExecution =>
        {
            _console.WriteLine("Hello World");
            handlesExecution.SafeExecute(0);
        })
        .Build();
}