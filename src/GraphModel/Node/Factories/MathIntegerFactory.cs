using GraphModel.Node.NodeBuilder.Pure;
using GraphModel.Values;

namespace GraphModel.Node.Factories;

public static class MathIntegerFactory
{
    public static INode CreateAddNode() => new PureNodeBuildable.Builder()
        .SetName("Add")
        .AddInputValueWithField("A", ValueTypeEnum.Int)
        .AddInputValueWithField("B", ValueTypeEnum.Int)
        .AddOutputValue("Result", ValueTypeEnum.Int)
        .SetExecution((output, input) =>
            output.CacheInt("Result", input.GetIntValue("A") + input.GetIntValue("B")))
        .Build();
    
    public static INode CreateSubtractNode() => new PureNodeBuildable.Builder()
        .SetName("Subtract")
        .AddInputValueWithField("A", ValueTypeEnum.Int)
        .AddInputValueWithField("B", ValueTypeEnum.Int)
        .AddOutputValue("Result", ValueTypeEnum.Int)
        .SetExecution((output, input) =>
            output.CacheInt("Result", input.GetIntValue("A") - input.GetIntValue("B")))
        .Build();
}