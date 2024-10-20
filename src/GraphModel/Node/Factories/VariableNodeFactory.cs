using CodingGame.Script.Graph.Model.Variable;
using GraphModel.Node.NodeBuilder;

namespace GraphModel.Node.Factories;

public class VariableNodeFactory
{
    public INode CreateSetVariable(IVariable variable) => new NodeBuildable.Builder()
        .SetName($"Set {variable.Name}")
        .SetIsPure(false)

        .AddInputFlow("")
        .AddInputValue("new value", variable.ValueType)

        .AddOutputFlow("")
        .SetExecution(execution =>
        {
            variable.SafeSetValue(execution.GetInputValue(1).Value);
            execution.SafeExecute(0);
        })
        .Build();
    
    public INode CreateGetVariable(IVariable variable) => new NodeBuildable.Builder()
        .SetName($"Get {variable.Name}")
        .SetIsPure(true)
        
        .AddOutputValue("value", variable.ValueType)
        
        .SetExecution(execution => execution.SetOutputValue(0, variable.GetValue()))
        .Build();
}