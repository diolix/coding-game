using GraphModel.Handle.Value.Input;
using GraphModel.NewValueTypes;

namespace GraphModel.Node.HandleBuilder.Value;

public class InputValueHandleBuilder : BaseValueHandleBuilder
{
    private record ValueHandleWithFieldValues(string Label, ValueTypeEnum ValueType) : ValueHandleValues(Label, ValueType);

    public void AddInputHandleWithField(string label, ValueTypeEnum valueType) =>
        HandlesValues.Add(new ValueHandleWithFieldValues(label, valueType));

    public override IEnumerable<InputValueHandle> Build(INode node) => HandlesValues.Select(handleValues => handleValues switch
    {
        ValueHandleWithFieldValues { Label: var label, ValueType: var valueType } =>
            new InputValueHandleWithField(label, valueType, node),
        { Label: var label, ValueType: var valueType } => new InputValueHandle(label, valueType, node)
    });
}