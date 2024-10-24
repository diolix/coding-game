using GraphModel.Handle.Value.Input;

namespace GraphModel.Node.Input;

public class InputValueManager
{
    private readonly IEnumerable<InputValueHandle> _handles;

    private IEnumerable<InputValueHandle> _inputValues = null!;

    public InputValueManager(IEnumerable<InputValueHandle> handles)
    {
        _handles = handles;
        InitializeInputValues();
    }

    private void InitializeInputValues()
    {
        _inputValues = _handles;
    }

    public bool GetBoolValue(string label) => SafeGetValue<bool>(label, ValueType.Bool);
    public int GetIntValue(string label) => SafeGetValue<int>(label, ValueType.Int);
    public string GetStringValue(string label) => SafeGetValue<string>(label, ValueType.String);
    public T GetValue<T>(string label, ValueType valueType)
    {
        var inputHandle = _inputValues.First(handle => handle.Label == label);

        if (inputHandle is null)
            throw new Exception($"Input value with label {label} not found");

        // ReSharper disable once ConvertTypeCheckPatternToNullCheck
        if (inputHandle is not InputValueHandle inputValueHandle)
            throw new Exception($"Input value with label {label} is not a value");

        if (!inputValueHandle.ValueType.Equals(valueType))
            throw new Exception($"Input value with label {label} is not a {valueType}");

        if (inputValueHandle.GetValue() is not T valueCasted)
            throw new InputValueWithNoValueException(inputValueHandle);

        return valueCasted;
    }
    
    public T SafeGetValue<T>(string label, ValueType valueType)
    {
        try
        {
            return GetValue<T>(label, valueType);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return default!;
        }
    }
}

public class InputValueWithNoValueException(InputValueHandle inputValueHandle)
    : Exception($"Input value with label : {inputValueHandle.Label} has no value")
{
    public InputValueHandle InputValueHandle { get; } = inputValueHandle;
}