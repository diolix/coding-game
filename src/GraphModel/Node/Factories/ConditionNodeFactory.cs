using GraphModel.Node.NodeBuilder;

namespace GraphModel.Node.Factories;

public class ConditionNodeFactory
{
    public INode CreateEqual() => new NodeBuildable.Builder()
        .SetName("Equal")
        .SetIsPure(true)
        .SetExecution(handlesExecution => handlesExecution.SetOutputValue(0,
            handlesExecution.GetInputValue(0).Value.
                Equals(handlesExecution.GetInputValue(1).Value)))
        .AddInputValue("A", ValueType.AnyValue)
        .AddInputValue("B", ValueType.AnyValue)
        .AddOutputValue("", ValueType.Bool)
        .Build();
    
    public INode CreateNot() => new NodeBuildable.Builder()
        .SetName("Not")
        .SetIsPure(true)
        .SetExecution(handlesExecution => handlesExecution.SetOutputValue(0,
            !handlesExecution.GetBoolInputValue(0).Value))
        .AddInputValue("", ValueType.Bool)
        .AddOutputValue("", ValueType.Bool)
        .Build();
    
    public INode CreateAnd() => new NodeBuildable.Builder()
        .SetName("And")
        .SetIsPure(true)
        .SetExecution(handlesExecution => handlesExecution.SetOutputValue(0,
            handlesExecution.GetBoolInputValue(0).Value &&
            handlesExecution.GetBoolInputValue(1).Value))
        .AddInputValue("A", ValueType.Bool)
        .AddInputValue("B", ValueType.Bool)
        .AddOutputValue("", ValueType.Bool)
        .Build();
    
    public INode CreateOr() => new NodeBuildable.Builder()
        .SetName("Or")
        .SetIsPure(true)
        .SetExecution(handlesExecution => handlesExecution.SetOutputValue(0,
            handlesExecution.GetBoolInputValue(0).Value ||
            handlesExecution.GetBoolInputValue(1).Value))
        .AddInputValue("A", ValueType.Bool)
        .AddInputValue("B", ValueType.Bool)
        .AddOutputValue("", ValueType.Bool)
        .Build();
}