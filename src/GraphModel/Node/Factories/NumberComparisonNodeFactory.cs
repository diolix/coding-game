using GraphModel.Node.NodeBuilder;

namespace GraphModel.Node.Factories;

public class NumberComparisonNodeFactory
{
    public INode CreateGreaterOrLowerThan() => new NodeBuildable.Builder()
        .SetName("< or >")
        .SetIsPure(true)
        .SetExecution(handlesExecution => handlesExecution.SetOutputValue(0,
            handlesExecution.GetIntInputValue(0).Value < handlesExecution.GetIntInputValue(1).Value))
        .AddInputValue("Lower", ValueType.Int)
        .AddInputValue("Greater", ValueType.Int)
        .AddOutputValue("", ValueType.Bool)
        .Build();
}