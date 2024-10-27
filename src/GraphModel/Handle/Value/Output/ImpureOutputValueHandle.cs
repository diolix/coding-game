using GraphModel.Node;
using GraphModel.Values;

namespace GraphModel.Handle.Value.Output;

public class ImpureOutputValueHandle(string label, ValueTypeEnum valueTypeEnum, INode node)
    : BaseOutputValueHandle(label, valueTypeEnum, node)
{
    public override Values.Value GetValue() => CachedValue;
}