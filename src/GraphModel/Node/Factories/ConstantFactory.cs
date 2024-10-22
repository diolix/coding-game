using GraphModel.Node.NodeBuilder.NewNode.Impure;
using GraphModel.Node.NodeBuilder.NewNode.Pure;

namespace GraphModel.Node.Factories;

public class ConstantFactory
{
    public INewNode CreatePureHelloWorldConstant() => new PureNodeBuildable.Builder()
        .SetName("HelloWorldConstant")
        .AddOutputValue("", ValueType.String)
        .SetExecution((outputManager, _) =>
        {
            outputManager.CacheValue("", "Hello World");
        })
        .Build();
    
    public INewNode CreateImpureHelloWorldConstant() => new ImpureNodeBuildable.Builder()
        .SetName("HelloWorldConstant")
        .AddInputFlow("")
        .AddOutputFlow("")
        .AddOutputValue("value", ValueType.String)
        .SetExecution((outputManager, _) =>
        {
            outputManager.CacheValue("value", "Hello World");
            outputManager.Execute("");
        })
        .Build();
    
    public INewNode CreateTrueConstant() => new PureNodeBuildable.Builder()
        .SetName("TrueConstant")
        .AddOutputValue("", ValueType.Bool)
        .SetExecution((outputManager, _) =>
        {
            outputManager.CacheValue("", true);
        })
        .Build();
    
    public INewNode CreateFalseConstant() => new PureNodeBuildable.Builder()
        .SetName("FalseConstant")
        .AddOutputValue("", ValueType.Bool)
        .SetExecution((outputManager, _) =>
        {
            outputManager.CacheValue("", false);
        })
        .Build();
}