using GraphModel.Node.BaseNodes;

namespace GraphModel.Node.NodeBuilder.Factories;

public class ConstantNodeFactory
{
    public INode CreateImpureHelloWorldContant() => new NodeBuildable.Builder()
        .SetName("Hello World Constant")
        .SetIsPure(false)
        
        .AddInputFlow("")
        
        .AddOutputFlow("")
        .AddOutputValue("Value", ValueType.String)
        
        .SetExecution(execution =>
        {
            execution.SetOutputValue(1, "Hello World");
            execution.SafeExecute(0);
        })
        .Build();
    
    public INode CreatePureHelloWorldContant() => new NodeBuildable.Builder()
        .SetName("Hello World Constant")
        .SetIsPure(true)
        .AddOutputValue("Value", ValueType.String)
        .SetExecution(execution =>
        {
            execution.SetOutputValue(0, "Hello World");
        })
        .Build();
}