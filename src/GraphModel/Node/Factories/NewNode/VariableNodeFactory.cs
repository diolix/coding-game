using CodingGame.Script.Graph.Model.Variable;
using GraphModel.Node.NodeBuilder.NewNode.Impure;
using GraphModel.Node.NodeBuilder.NewNode.Pure;

namespace GraphModel.Node.Factories.NewNode;

public class VariableNodeFactory
{
    public INewNode CreateSetVariable(IVariable variable) => new ImpureNodeBuildable.Builder()
        .SetName($"Set {variable.Name}")
        .AddInputFlow("")
        .AddInputValue("new value", variable.ValueType)
        .AddOutputFlow("")
        .SetExecution((outputManager, inputManager) =>
        {
            variable.SafeSetValue(inputManager.GetValue("new value").Value);
            outputManager.Execute("");
        })
        .Build();
    
    public INewNode CreateGetVariable(IVariable variable) => new PureNodeBuildable.Builder()
        .SetName($"Get {variable.Name}")
        .AddOutputValue("value", variable.ValueType)
        .SetExecution((outputManager, inputManager) => outputManager.CacheValue("value", variable.GetValue()))
        .Build();
}