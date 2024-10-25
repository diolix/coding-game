using GraphModel.Handle.Value.Input;
using GraphModel.NewValueTypes;
using GraphModel.NewValueTypes.PrimitiveType;

namespace GraphModel.Node.Input;

public class InputValueManager(IEnumerable<InputValueHandle> handles)
{
    private InputValueHandle GetHandle(string label) => handles.First(handle => handle.Label == label);

    public bool GetBoolValue(string label) =>
        GetHandle(label).GetValue() is BoolValue boolValue
            ? boolValue.GetValue()
            : throw new GetValueException(GetHandle(label));

    public string GetStringValue(string label) => 
        GetHandle(label).IsOfType(ValueTypeEnum.String) stringValue
            ? stringValue.GetValue()
            : throw new GetValueException(GetHandle(label));

    public object GetObjectValue(string label) => 
        GetHandle(label).GetValue() is ObjectValue objectValue
            ? objectValue.GetValue()
            : throw new GetValueException(GetHandle(label));
    
    public Value GetValue(string label, ValueTypeEnum valueTypeEnum) =>
        GetHandle(label).GetValue() is { } value && value.IsOfType(valueTypeEnum)
            ? value
            : throw new GetValueException(GetHandle(label));
}

public class GetValueException(InputValueHandle inputValueHandle)
    : Exception($"Problem getting value from input value handle {inputValueHandle.Label}")
{
    public InputValueHandle InputValueHandle { get; } = inputValueHandle;
}