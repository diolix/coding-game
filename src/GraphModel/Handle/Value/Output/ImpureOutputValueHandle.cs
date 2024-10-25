using GraphModel.NewValueTypes;
using GraphModel.Node;
using GraphModel.Util;

namespace GraphModel.Handle.Value.Output;

public class ImpureOutputValueHandle(string label, ValueTypeEnum valueTypeEnum, INode node)
    : BaseOutputValueHandle(label, valueTypeEnum, node)
{
    public override NewValueTypes.Value GetValue() => CachedValue;
}