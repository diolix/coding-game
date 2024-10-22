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