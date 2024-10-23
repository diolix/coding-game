using GraphModel.Handle;
using GraphModel.Handle.Flow;
using GraphModel.Util;

namespace GraphModel.Edge;

public class FlowEdge : IEdge
{
    public ColorHex Color => _to.Color;

    private readonly InputFlowHandle _to;
    private readonly OutputFlowHandle _from;

    public static FlowEdge Create(OutputFlowHandle from, InputFlowHandle to)
    {
        if (from.HasEdge)
            throw new MultipleFlowEdgesFromSameOutputException(from, to);
        var edge = new FlowEdge(from, to);
        from.FlowEdge = edge;
        return edge;
    }

    private FlowEdge(OutputFlowHandle from, InputFlowHandle to)
    {
        _to = to;
        _from = from;
    }

    public void ExecuteInputFlow() => _to.Execute();
    public void Remove() => _from.FlowEdge = null;
    public bool Contains(IHandle handle) => handle == _from || handle == _to;
}

public class MultipleFlowEdgesFromSameOutputException(OutputFlowHandle from, InputFlowHandle to)
    : Exception(
        $"Multiple flow edges from the same input when trying to create a new edge between from : {from} and to : {to}");