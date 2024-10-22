using CodingGame.Script.Util;
using GraphModel.Edge;
using GraphModel.Util;

namespace GraphModel.Handle.Value;

public class InputValueHandle(string label, ValueType valueType) : BaseHandle(label)
{
    public ValueType ValueType { get; } = valueType;
    public ValueEdge? Edge { private get; set; }

    public override ColorHex Color => ValueType.GetColor();

    public override bool IsCompatible(IHandle handle)
    {
        return handle is BaseOutputValueHandle outputValueHandle &&
               outputValueHandle.ValueType.Equals(ValueType);
    }

    public Optional<object> GetValue()
    {
        return Edge is null ? new Optional<object>() : Edge.GetOutputValue();
    }

}