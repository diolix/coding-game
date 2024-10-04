using CodingGame.Script.Graph.Model.Node.BaseNodes;
using CodingGame.Script.Graph.Model.Variable;

namespace CodingGame.Script.Graph.Model.Node.Nodes.VariableNodes;

public abstract class VariableNode : PrimitiveNode
{
    protected IVariable Variable;
    
    public VariableNode(IVariable variable)
    {
        variable.ValueType.CoherentTypeAndValueType(variable.GetValue().GetType());
        Variable = variable;
    }
}