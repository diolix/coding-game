using GraphModel.NewHandle.Flow;
using GraphModel.Util;

namespace GraphModel.NewEdge;

public class FlowEdge : INewEdge
{
    public ColorHex Color => _to.Color;
    private readonly InputFlowHandle _to;
    public static FlowEdge Create(OutputFlowHandle from, InputFlowHandle to)
    {
        var edge = new FlowEdge(to);
        from.FlowEdge = edge;
        return edge;
    }

    private FlowEdge(InputFlowHandle to)
    {
        _to = to;
    }

    public void ExecuteInputFlow()
    {
        _to.Execute();
    }
}