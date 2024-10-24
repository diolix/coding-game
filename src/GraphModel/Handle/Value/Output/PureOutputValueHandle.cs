using GraphModel.Node;

namespace GraphModel.Handle.Value.Output;

public class PureOutputValueHandle(string label, ValueType valueType, INode node)
    : BaseOutputValueHandle(label, valueType, node)
{
    public override object?  GetValue()
    {
        Node.Execute();
        return CachedValue;
    }
}