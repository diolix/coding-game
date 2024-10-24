using GraphModel.Node.NodeBuilder.NewNode.Pure;

namespace GraphModel.Node.Factories;

public static class LogicFactory
{
    public static INode CreateAnd() => new PureNodeBuildable.Builder()
        .SetName("And")
        .AddInputValue("a", ValueType.Bool)
        .AddInputValue("b", ValueType.Bool)
        .AddOutputValue("result", ValueType.Bool)
        .SetExecution((outputManager, inputManager) =>
        {
            outputManager.CacheValue("result", inputManager.GetBoolValue("a") && inputManager.GetBoolValue("b"));
        }).Build();
    
    public static INode CreateOr() => new PureNodeBuildable.Builder()
        .SetName("Or")
        .AddInputValue("a", ValueType.Bool)
        .AddInputValue("b", ValueType.Bool)
        .AddOutputValue("result", ValueType.Bool)
        .SetExecution((outputManager, inputManager) =>
        {
            outputManager.CacheValue("result", inputManager.GetBoolValue("a") || inputManager.GetBoolValue("b"));
        }).Build();
    
    public static INode CreateNot() => new PureNodeBuildable.Builder()
        .SetName("Not")
        .AddInputValue("a", ValueType.Bool)
        .AddOutputValue("result", ValueType.Bool)
        .SetExecution((outputManager, inputManager) =>
        {
            outputManager.CacheValue("result", !inputManager.GetBoolValue("a"));
        }).Build();
    
    public static INode CreateGreater() => new PureNodeBuildable.Builder()
        .SetName("Greater")
        .AddInputValue("a", ValueType.Int)
        .AddInputValue("b", ValueType.Int)
        .AddOutputValue("result", ValueType.Bool)
        .SetExecution((outputManager, inputManager) =>
        {
            outputManager.CacheValue("result", inputManager.GetIntValue("a") > inputManager.GetIntValue("b"));
        }).Build();
    
    public static INode CreateLess() => new PureNodeBuildable.Builder()
        .SetName("Less")
        .AddInputValue("a", ValueType.Int)
        .AddInputValue("b", ValueType.Int)
        .AddOutputValue("result", ValueType.Bool)
        .SetExecution((outputManager, inputManager) =>
        {
            outputManager.CacheValue("result", inputManager.GetIntValue("a") < inputManager.GetIntValue("b"));
        }).Build();
}