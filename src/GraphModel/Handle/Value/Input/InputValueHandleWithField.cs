using GraphModel.Node;
using GraphModel.Values;

namespace GraphModel.Handle.Value.Input;

public class InputValueHandleWithField(string label, ValueTypeEnum valueTypeEnum, INode node)
    : InputValueHandle(label, valueTypeEnum, node)
{
    private readonly Values.Value _valueSetWithField = ValueFactory.CreateValue(valueTypeEnum);

    public void SetValue(object value)
    {
        _valueSetWithField.SetObjValue(value);
    }

    public override Values.Value GetValue() => HasEdge ? base.GetValue() : _valueSetWithField;
}