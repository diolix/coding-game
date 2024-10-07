namespace GraphModel.Node.NodeBuilder.Factories;

public class ControlFlowNodeFactory
{
    public INode CreateIf() => new NodeBuildable.Builder()
        .SetName("if")
        .SetIsPure(false)

        .AddInputFlow("")
        .AddInputValue("Condition", ValueType.Bool)

        .AddOutputFlow("true")
        .AddOutputFlow("false")

        .SetExecution(execution =>
        {
            if(execution.GetBoolInputValue(1).Value)
                execution.SafeExecute(0);
            else execution.SafeExecute(1);
        }).Build();
    
    public INode CreateWhile() => new NodeBuildable.Builder()
        .SetName("while")
        .SetIsPure(false)

        .AddInputFlow("")
        .AddInputValue("Condition", ValueType.Bool)

        .AddOutputFlow("exit")
        .AddOutputFlow("body")

        .SetExecution(execution =>
        {
            while(execution.GetBoolInputValue(1).Value)
                execution.SafeExecute(1);
            execution.SafeExecute(0);
        }).Build();
}