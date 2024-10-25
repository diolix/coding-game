using GraphModel.NewValueTypes;
using GraphModel.Node;

namespace GraphModel.Handle.Value.Input;

public class InputValueHandleWithField(string label, ValueTypeEnum valueTypeEnum, INode node)
    : InputValueHandle(label, valueTypeEnum, node)
{
    private readonly NewValueTypes.Value _valueSetWithField = ValueFactory.CreateValue(valueTypeEnum);

    public void SetValue(object value)
    {
        _valueSetWithField.SetObjValue(value);
    }

    public override NewValueTypes.Value GetValue() => HasEdge ? base.GetValue() : _valueSetWithField;
}