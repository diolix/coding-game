using GraphModel.Node.NodeBuilder.Pure;
using GraphModel.Values;

namespace GraphModel.Node.Factories;

public static class LogicFactory
{
    public static INode CreateAnd() => new PureNodeBuildable.Builder()
        .SetName("And")
        .AddInputValue("a", ValueTypeEnum.Bool)
        .AddInputValue("b", ValueTypeEnum.Bool)
        .AddOutputValue("result", ValueTypeEnum.Bool)
        .SetExecution((outputManager, inputManager) =>
        {
            outputManager.CacheBool("result", inputManager.GetBoolValue("a") && inputManager.GetBoolValue("b"));
        }).Build();

    public static INode CreateOr() => new PureNodeBuildable.Builder()
        .SetName("Or")
        .AddInputValue("a", ValueTypeEnum.Bool)
        .AddInputValue("b", ValueTypeEnum.Bool)
        .AddOutputValue("result", ValueTypeEnum.Bool)
        .SetExecution((outputManager, inputManager) =>
        {
            outputManager.CacheBool("result", inputManager.GetBoolValue("a") || inputManager.GetBoolValue("b"));
        }).Build();

    public static INode CreateNot() => new PureNodeBuildable.Builder()
        .SetName("Not")
        .AddInputValue("a", ValueTypeEnum.Bool)
        .AddOutputValue("result", ValueTypeEnum.Bool)
        .SetExecution((outputManager, inputManager) =>
        {
            outputManager.CacheBool("result", !inputManager.GetBoolValue("a"));
        }).Build();

    /*public static INode CreateGreater() => new PureNodeBuildable.Builder()
        .SetName("Greater")
        .AddInputValue("a", ValueType.Int)
        .AddInputValue("b", ValueType.Int)
        .AddOutputValue("result", ValueTypeEnum.Bool)
        .SetExecution((outputManager, inputManager) =>
        {
            outputManager.CacheBool("result", inputManager.GetIntValue("a") > inputManager.GetIntValue("b"));
        }).Build();

    public static INode CreateLess() => new PureNodeBuildable.Builder()
        .SetName("Less")
        .AddInputValue("a", ValueType.Int)
        .AddInputValue("b", ValueType.Int)
        .AddOutputValue("result", ValueType.Bool)
        .SetExecution((outputManager, inputManager) =>
        {
            outputManager.CacheValue("result", inputManager.GetIntValue("a") < inputManager.GetIntValue("b"));
        }).Build();*/
}