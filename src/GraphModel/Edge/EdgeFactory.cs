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
    
    public static IEdge CreateEdge(IHandle from, IHandle to)
    {
        if (!from.IsCompatible(to))
            throw new HandlesNotCompatibleException(from, to);

        return from switch
        {
            BaseOutputValueHandle fromValue when to is InputValueHandle toValue => ValueEdge.Create(fromValue, toValue),
            OutputFlowHandle fromFlow when to is InputFlowHandle toFlow => FlowEdge.Create(fromFlow, toFlow),
            _ => throw new ArgumentException("Unsupported edge type")
        };
    }
}

public class HandlesNotCompatibleException(IHandle from, IHandle to)
    : Exception($"from: {from} and to: ${to} are not compatible");