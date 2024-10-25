using GraphModel.NewValueTypes;
using GraphModel.Node.NodeBuilder.Pure;
using ImpureNodeBuildable = GraphModel.Node.NodeBuilder.Impure.ImpureNodeBuildable;

namespace GraphModel.Node.Factories;

public static class ConstantFactory
{
    public static INode CreatePureHelloWorldConstant() => new PureNodeBuildable.Builder()
        .SetName("HelloWorldConstant")
        .AddOutputValue("", ValueTypeEnum.String)
        .SetExecution((outputManager, _) =>
        {
            outputManager.CacheString("", "Hello World");
        })
        .Build();
    
    public static INode CreateImpureHelloWorldConstant() => new ImpureNodeBuildable.Builder()
        .SetName("HelloWorldConstant")
        .AddInputFlow("")
        .AddOutputFlow("")
        .AddOutputValue("value", ValueTypeEnum.String)
        .SetExecution((outputManager, _) =>
        {
            outputManager.CacheString("value", "Hello World");
            outputManager.Execute("");
        })
        .Build();
    
    public static INode CreateTrueConstant() => new PureNodeBuildable.Builder()
        .SetName("TrueConstant")
        .AddOutputValue("", ValueTypeEnum.Bool)
        .SetExecution((outputManager, _) =>
        {
            outputManager.CacheBool("", true);
        })
        .Build();
    
    public static INode CreateFalseConstant() => new PureNodeBuildable.Builder()
        .SetName("FalseConstant")
        .AddOutputValue("", ValueTypeEnum.Bool)
        .SetExecution((outputManager, _) =>
        {
            outputManager.CacheBool("", false);
        })
        .Build();
}