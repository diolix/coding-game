using GraphModel.Node;
using GraphModel.Util;

namespace GraphModel.Handle.Value.Output;

public class PureOutputValueHandle(string label, ValueType valueType, INode node)
    : BaseOutputValueHandle(label, valueType, node)
{
    public override Optional<object> GetValue()
    {
        Node.Execute();
        return CachedValue;
    }
}