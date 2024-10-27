using GraphModel.Node.NodeBuilder.Pure;
using GraphModel.Values;
using GraphModel.Variable;
using ImpureNodeBuildable = GraphModel.Node.NodeBuilder.Impure.ImpureNodeBuildable;

namespace GraphModel.Node.Factories;

public static class VariableNodeFactory
{
    public static INode CreateSetVariable(IVariable variable) => new ImpureNodeBuildable.Builder()
        .SetName($"Set {variable.Name}")
        .AddInputFlow("")
        .AddInputValue("new value", variable.AsTypeEnum)
        .AddOutputFlow("")
        .SetExecution((outputManager, inputManager) =>
        {
            Value value = inputManager.GetValue("new value", variable.AsTypeEnum);
            variable.SetValue(value);
            outputManager.Execute("");
        })
        .Build();
    
    public static INode CreateGetVariable(IVariable variable) => new PureNodeBuildable.Builder()
        .SetName($"Get {variable.Name}")
        .AddOutputValue("value", variable.AsTypeEnum)
        .SetExecution((outputManager, _) => outputManager.Cache("value", variable.Value))
        .Build();
}