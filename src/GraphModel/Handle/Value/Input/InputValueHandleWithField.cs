using GraphModel.Node;

namespace GraphModel.Handle.Value.Input;

public class InputValueHandleWithField(string label, ValueType valueType, INode node)
    : InputValueHandle(label, valueType, node)
{
    private object? _valueSetWithField;

    public void SetValue(object value)
    {
        ValueType.CoherentTypeAndValueType(value.GetType());
        _valueSetWithField = value;
    }

    public override object? GetValue() => HasEdge ? base.GetValue() : _valueSetWithField;
}