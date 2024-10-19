using CodingGame.Script.Util;
using GraphModel.NewEdge;
using GraphModel.Util;

namespace GraphModel.NewHandle.Value;

public class InputValueHandle(string label, ValueType valueType) : BaseNewHandle(label)
{
    public ValueType ValueType { get; } = valueType;
    public ValueEdge? Edge { private get; set; }

    public override ColorHex Color => ValueType.GetColor();

    public override bool IsCompatible(INewHandle handle)
    {
        return handle is ImpureOutputValueHandle outputValueHandle &&
               outputValueHandle.ValueType.Equals(ValueType);
    }

    public Optional<object> GetValue()
    {
        return Edge is null ? new Optional<object>() : Edge.GetOutputValue();
    }

}