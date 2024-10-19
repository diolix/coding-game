using CodingGame.Script.Util;
using GraphModel.NewHandle.Value;
using GraphModel.Util;

namespace GraphModel.NewEdge;

public class ValueEdge : INewEdge
{
    public ColorHex Color => _from.Color;
    private readonly BaseOutputValueHandle _from;
    public static ValueEdge Create(BaseOutputValueHandle from, InputValueHandle to)
    {
        var edge = new ValueEdge(from);
        to.Edge = edge;
        return edge;
    }
    private ValueEdge(BaseOutputValueHandle from)
    {
        _from = from;
    }

    public Optional<object> GetOutputValue() => _from.GetCachedValue();
}