using GraphModel.Handle;
using GraphModel.Handle.Flow;
using GraphModel.Handle.Value;
using GraphModel.Node;

namespace GraphModel.Edge;

public class EdgeFactory
{
    public IEdge CreateEdge(INewNode from, string labelFrom, INewNode to, string labelTo)
    {
        return CreateEdge(from.GetOutputHandle(labelFrom), to.GetInputHandle(labelTo));
    }
    
    public IEdge CreateEdge(IHandle from, IHandle to)
    {
        if (!from.IsCompatible(to))
            throw new ArgumentException("Handles must be compatible");

        if (from is BaseOutputValueHandle input && to is InputValueHandle output)
            return ValueEdge.Create(input, output);
        
        if (from is OutputFlowHandle fromFlow && to is InputFlowHandle toFlow)
            return FlowEdge.Create(fromFlow, toFlow);
        
        throw new ArgumentException("Unsupported edge type");
    }
}