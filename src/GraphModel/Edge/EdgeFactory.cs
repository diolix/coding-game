using GraphModel.Handle;
using GraphModel.Handle.Flow;
using GraphModel.Handle.Value;
using GraphModel.Handle.Value.Output;
using GraphModel.Node;

namespace GraphModel.Edge;

public class EdgeFactory
{
    public IEdge CreateEdge(INode from, string labelFrom, INode to, string labelTo)
    {
        return CreateEdge(from.GetOutputHandle(labelFrom), to.GetInputHandle(labelTo));
    }
    
    public IEdge CreateEdge(IHandle from, IHandle to)
    {
        if (!from.IsCompatible(to))
            throw new HandlesNotCompatibleException(from, to);

        if (from is BaseOutputValueHandle input && to is InputValueHandle output)
            return ValueEdge.Create(input, output);
        
        if (from is OutputFlowHandle fromFlow && to is InputFlowHandle toFlow)
            return FlowEdge.Create(fromFlow, toFlow);
        
        throw new ArgumentException("Unsupported edge type");
    }

    public class HandlesNotCompatibleException(IHandle from, IHandle to)
        : Exception($"from: {from} and to ${to} are not comptatible");
}