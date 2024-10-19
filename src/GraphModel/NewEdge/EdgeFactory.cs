using GraphModel.NewHandle;
using GraphModel.NewHandle.Flow;
using GraphModel.NewHandle.Value;
using GraphModel.Node;

namespace GraphModel.NewEdge;

public class EdgeFactory
{
    public INewEdge CreateEdge(INewNode from, string labelFrom, INewNode to, string labelTo)
    {
        return CreateEdge(from.GetOutputHandle(labelFrom), to.GetInputHandle(labelTo));
    }
    
    public INewEdge CreateEdge(INewHandle from, INewHandle to)
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