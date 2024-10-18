using CodingGame.Script.Util;
using GraphModel.NewEdge;
using GraphModel.Util;

namespace GraphModel.NewHandle.Value.Impure;

public class ImpureInputValueHandle : BaseNewHandle
{
    public ValueType ValueType { get; }
    public ValueEdge Edge { private get; set; }

    public override ColorHex Color => ValueType.GetColor();

    public ImpureInputValueHandle(string label, ValueType valueType) : base(label)
    {
        ValueType = valueType;
    }
    public override bool IsCompatible(INewHandle handle)
    {
        return handle is ImpureOutputValueHandle outputValueHandle && 
               outputValueHandle.ValueType.Equals(ValueType);
    }

    public Optional<object> GetValue()
    {
        return Edge.GetOutputValue();
    }
}