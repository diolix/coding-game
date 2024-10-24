using GraphModel.Node;
using GraphModel.Util;

namespace GraphModel.Handle.Value.Output;

public class ImpureOutputValueHandle(string label, ValueType valueType, INode node)
    : BaseOutputValueHandle(label, valueType, node)
{
    public override Optional<object> GetValue() => CachedValue;
}