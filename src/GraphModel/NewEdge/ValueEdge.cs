using CodingGame.Script.Util;
using GraphModel.NewHandle.Value.Impure;
using GraphModel.Util;

namespace GraphModel.NewEdge;

public class ValueEdge : INewEdge
{
    public ColorHex Color => _from.Color;
    private readonly ImpureOutputValueHandle _from;
    public static ValueEdge Create(ImpureOutputValueHandle from, ImpureInputValueHandle to)
    {
        var edge = new ValueEdge(from);
        to.Edge = edge;
        return edge;
    }
    private ValueEdge(ImpureOutputValueHandle from)
    {
        _from = from;
    }

    public Optional<object> GetOutputValue() => _from.GetCachedValue();
}