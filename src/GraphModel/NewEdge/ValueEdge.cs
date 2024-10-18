using CodingGame.Script.Util;
using GraphModel.NewHandle.Value.Impure;

namespace GraphModel.NewEdge;

public class ValueEdge : NewEdge
{
    private ImpureOutputValueHandle _from;
    public static ValueEdge Create(ImpureOutputValueHandle from, ImpureOutputValueHandle to)
    {
        var edge = new ValueEdge(from, to);
        return edge;
    }
    internal ValueEdge(ImpureOutputValueHandle from, ImpureOutputValueHandle to) : base(from, to)
    {
        _from = from;
    }

    public Optional<object> GetOutputValue() => _from.GetCachedValue();
}