using GraphModel.Handle;
using GraphModel.Handle.Value.Input;
using GraphModel.Handle.Value.Output;
using GraphModel.Util;

namespace GraphModel.Edge;

public class ValueEdge : IEdge
{
    public ColorHex Color => _from.Color;
    private readonly BaseOutputValueHandle _from;
    private readonly InputValueHandle _to;

    public static ValueEdge Create(BaseOutputValueHandle from, InputValueHandle to)
    {
        if (to.HasEdge)
            throw new MultipleValueEdgesToSameInputException(from, to);
        var edge = new ValueEdge(from, to);
        to.Edge = edge;
        return edge;
    }

    private ValueEdge(BaseOutputValueHandle from, InputValueHandle to)
    {
        _from = from;
        _to = to;
    }

    public void Remove() => _to.Edge = null;
    public bool Contains(IHandle handle) => handle == _from || handle == _to;
    public object? GetOutputValue() => _from.GetValue();
}

public class MultipleValueEdgesToSameInputException(BaseOutputValueHandle from, InputValueHandle to)
    : Exception(
        $"Multiple value edges to the same input when trying to create a new edge between from : {from} and to : {to}");