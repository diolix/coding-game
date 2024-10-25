using GraphModel.NewValueTypes;
using GraphModel.Node;

namespace GraphModel.Handle.Value.Output;

public class PureOutputValueHandle(string label, ValueTypeEnum valueTypeEnum, INode node)
    : BaseOutputValueHandle(label, valueTypeEnum, node)
{
    public override NewValueTypes.Value GetValue()
    {
        Node.Execute();
        return CachedValue;
    }
}