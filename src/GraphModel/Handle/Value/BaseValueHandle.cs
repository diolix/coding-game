using GraphModel.NewValueTypes;
using GraphModel.Node;
using GraphModel.Util;

namespace GraphModel.Handle.Value;

public abstract class BaseValueHandle(string label, ValueTypeEnum valueTypeEnum, INode node) : BaseHandle(label, node)
{
    public ValueTypeEnum ValueTypeEnum { get; } = valueTypeEnum;
    public override ColorHex Color => ValueTypeColor.ColorFor(ValueTypeEnum);
    public abstract NewValueTypes.Value GetValue();
}