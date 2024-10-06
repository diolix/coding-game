using CodingGame.Script.Graph.Model.Node.Nodes.VariableNodes;
using CodingGame.Script.Graph.Model.Variable;
using GraphModel.Node.BaseNodes;

namespace GraphModel.Node.Factory;

public class VariableNodeFactory
{
    public INode CreateSetVariable(IVariable variable) => Configure(new SetVariable(variable));
    public INode CreateGetVariable(IVariable variable) => Configure(new GetVariable(variable));
    
    private INode Configure(CodingGame.Script.Graph.Model.Node.BaseNodes.Node node)
    {
        node.Configure();
        return node;
    }
}