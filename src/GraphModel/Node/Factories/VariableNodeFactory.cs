using CodingGame.Script.Graph.Model.Variable;
using GraphModel.Node.NodeBuilder.NewNode.Impure;
using GraphModel.Node.NodeBuilder.NewNode.Pure;

namespace GraphModel.Node.Factories;

public static class VariableNodeFactory
{
    public static INode CreateSetVariable(IVariable variable) => new ImpureNodeBuildable.Builder()
        .SetName($"Set {variable.Name}")
        .AddInputFlow("")
        .AddInputValue("new value", variable.ValueType)
        .AddOutputFlow("")
        .SetExecution((outputManager, inputManager) =>
        {
            variable.SafeSetValue(inputManager.GetValue<object>("new value", variable.ValueType));
            outputManager.Execute("");
        })
        .Build();
    
    public static INode CreateGetVariable(IVariable variable) => new PureNodeBuildable.Builder()
        .SetName($"Get {variable.Name}")
        .AddOutputValue("value", variable.ValueType)
        .SetExecution((outputManager, _) => outputManager.CacheValue("value", variable.GetValue()))
        .Build();
}