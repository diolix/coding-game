using GraphModel.Node;
using GraphModel.Util;
using GraphModel.Values;

namespace GraphModel.Handle.Value;

public abstract class BaseValueHandle(string label, ValueTypeEnum valueTypeEnum, INode node) : BaseHandle(label, node)
{
    public ValueTypeEnum ValueTypeEnum { get; } = valueTypeEnum;
    public override ColorHex Color => ValueTypeColor.ColorFor(ValueTypeEnum);
    public abstract Values.Value GetValue();
}