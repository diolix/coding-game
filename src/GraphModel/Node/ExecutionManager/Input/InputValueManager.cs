using GraphModel.Handle.Value.Input;
using GraphModel.NewValueTypes;
using GraphModel.NewValueTypes.PrimitiveType;
using GraphModel.Values.PrimitiveType;

namespace GraphModel.Node.ExecutionManager.Input;

public class InputValueManager(IEnumerable<InputValueHandle> handles)
{
    private InputValueHandle? GetHandle(string label) => handles.FirstOrDefault(handle => handle.Label == label);

    public bool GetBoolValue(string label) =>
        GetHandle(label)?.GetValue() is BoolValue boolValue
            ? boolValue.GetValue()
            : throw new HandleValueNonexistentException(label, ValueTypeEnum.Bool);

    public string GetStringValue(string label) =>
        GetHandle(label)?.GetValue() is StringValue stringValue
            ? stringValue.GetValue()
            : throw new HandleValueNonexistentException(label, ValueTypeEnum.String);

    public object GetObjectValue(string label) =>
        GetHandle(label)?.GetValue() is ObjectValue objectValue
            ? objectValue.GetValue()
            : throw new HandleValueNonexistentException(label, ValueTypeEnum.Object);
    
    public Value GetValue(string label, ValueTypeEnum valueTypeEnum) =>
        GetHandle(label)?.GetValue() is { } value && value.IsOfType(valueTypeEnum)
            ? value
            : throw new HandleValueNonexistentException(label, valueTypeEnum);
}