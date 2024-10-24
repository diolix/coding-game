using GraphModel.Node;
using GraphModel.Util;

namespace GraphModel.Handle.Value;

public abstract class BaseValueHandle(string label, ValueType valueType, INode node) : BaseHandle(label, node)
{
    public ValueType ValueType { get; } = valueType;
    public override ColorHex Color => ValueType.GetColor();
    public abstract object? GetValue();
}