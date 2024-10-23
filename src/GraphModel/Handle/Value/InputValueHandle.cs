using GraphModel.Edge;
using GraphModel.Handle.Value.Output;
using GraphModel.Node;
using GraphModel.Util;

namespace GraphModel.Handle.Value;

public class InputValueHandle(string label, ValueType valueType, INode node) : BaseHandle(label, node)
{
    public ValueType ValueType { get; } = valueType;
    public ValueEdge? Edge { private get; set; }
    public bool HasEdge => Edge != null;
    public override ColorHex Color => ValueType.GetColor();

    protected override bool IsCompatible(IHandle handle)
    {
        return handle is BaseOutputValueHandle outputValueHandle &&
               outputValueHandle.ValueType.Equals(ValueType);
    }

    public Optional<object> GetValue()
    {
        return Edge is null ? new Optional<object>() : Edge.GetOutputValue();
    }

}