using GraphModel.NewHandle.Flow;

namespace GraphModel.NewEdge;

public class FlowEdge : NewEdge
{
    private readonly InputFlowHandle _to;
    public static FlowEdge Create(OutputFlowHandle from, InputFlowHandle to)
    {
        var edge = new FlowEdge(from, to);
        from.FlowEdge = edge;
        return edge;
    }

    private FlowEdge(OutputFlowHandle from, InputFlowHandle to) : base(from, to)
    {
        _to = to;
    }

    public void ExecuteInputFlow()
    {
        _to.Execute();
    }
}