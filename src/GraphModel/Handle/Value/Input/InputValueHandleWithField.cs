using GraphModel.Node;
using GraphModel.Util;

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

    public override Optional<object> GetValue()
    {
        if (HasEdge) return base.GetValue();
        return _valueSetWithField is null ? new Optional<object>() : new Optional<object>(_valueSetWithField);
    }
}