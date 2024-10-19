using GraphModel.Node.NodeBuilder.NewNode.Pure;

namespace GraphModel.Node.Factories.NewNode;

public class ConstantFactory
{
    public INewNode CreateHelloWorldConstant() => new PureNodeBuildable.Builder()
        .SetName("HelloWorldConstant")
        .AddOutputValue("", ValueType.String)
        .SetExecution((_, outputManager) =>
        {
            outputManager.CacheValue("", "Hello World");
        })
        .Build();
    
    public INewNode CreateTrueConstant() => new PureNodeBuildable.Builder()
        .SetName("TrueConstant")
        .AddOutputValue("", ValueType.Bool)
        .SetExecution((_, outputManager) =>
        {
            outputManager.CacheValue("", true);
        })
        .Build();
    
    public INewNode CreateFalseConstant() => new PureNodeBuildable.Builder()
        .SetName("FalseConstant")
        .AddOutputValue("", ValueType.Bool)
        .SetExecution((_, outputManager) =>
        {
            outputManager.CacheValue("", false);
        })
        .Build();
}