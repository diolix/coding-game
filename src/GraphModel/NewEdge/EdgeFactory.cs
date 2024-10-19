using GraphModel.NewHandle;
using GraphModel.NewHandle.Flow;
using GraphModel.NewHandle.Value.Impure;

namespace GraphModel.NewEdge;

public class EdgeFactory
{
    public INewEdge CreateEdge(INewHandle from, INewHandle to)
    {
        if (!from.IsCompatible(to))
            throw new ArgumentException("Handles must be compatible");

        if (from is ImpureOutputValueHandle input && to is ImpureInputValueHandle output)
            return ValueEdge.Create(input, output);
        
        if (from is OutputFlowHandle fromFlow && to is InputFlowHandle toFlow)
            return FlowEdge.Create(fromFlow, toFlow);
        
        throw new ArgumentException("Unsupported edge type");
    }
}