using CodingGame.Script.Util;
using GraphModel.Node;
using GraphModel.Util;

namespace GraphModel.Handle.Value;

public class PureOutputValueHandle : BaseOutputValueHandle
{
    private readonly INewNode _node;
    public PureOutputValueHandle(string label, ValueType valueType, INewNode node) : base(label, valueType)
    {
        _node = node;
    }

    public override Optional<object> GetCachedValue()
    {
        _node.Execute();
        return CachedValue;
    }
}