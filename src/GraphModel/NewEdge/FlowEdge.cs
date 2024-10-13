using GraphModel.NewHandle;
using GraphModel.NewHandle.Interfaces;

namespace GraphModel.NewEdge;

public class FlowEdge : NewEdge
{
    public static NewEdge Create(IInputNewHandle from, IOutputNewHandle to)
    {
        var edge = new NewEdge(from, to);
        from.AddEdge(edge);
        to.AddEdge(edge);
        return edge;
    }
    
    internal FlowEdge(IInputNewHandle from, IOutputNewHandle to) : base(from, to)
    {
    }
}