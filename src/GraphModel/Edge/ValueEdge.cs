using CodingGame.Script.Util;
using GraphModel.Handle;
using GraphModel.Handle.Value;
using GraphModel.Util;

namespace GraphModel.Edge;

public class ValueEdge : IEdge
{
    public ColorHex Color => _from.Color;
    private readonly BaseOutputValueHandle _from;
    private readonly InputValueHandle _to;
    public static ValueEdge Create(BaseOutputValueHandle from, InputValueHandle to)
    {
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

    public Optional<object> GetOutputValue() => _from.GetCachedValue();
}