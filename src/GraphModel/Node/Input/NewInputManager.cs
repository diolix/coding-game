using CodingGame.Script.Util;
using GraphModel.NewHandle;
using GraphModel.NewHandle.Value;

namespace GraphModel.Node.Input;

public class NewInputManager
{
    private readonly IEnumerable<INewHandle> _handles;
    public IEnumerable<INewHandle> Handles => _handles;

    private IEnumerable<InputValueHandle> _inputValues = null!;

    public NewInputManager(IEnumerable<INewHandle> handles)
    {
        _handles = handles;
        InitializeInputValues();
    }

    private void InitializeInputValues()
    {
        _inputValues = _handles.OfType<InputValueHandle>();
    }

    public Optional<object> GetValue(string label)
    {
        return _inputValues.First(handle => handle.Label == label).GetValue();
    }

    public bool GetBoolValue(string label) => GetValue<bool>(label, ValueType.Bool);
    public int GetIntValue(string label) => GetValue<int>(label, ValueType.Int);
    public string GetStringValue(string label) => GetValue<string>(label, ValueType.String);


    private T GetValue<T>(string label, ValueType valueType)
    {
        var inputHandle = _inputValues.First(handle => handle.Label == label);

        if (inputHandle is null)
        {
            throw new Exception($"Input value with label {label} not found");
        }

        if (inputHandle is not InputValueHandle inputValueHandle)
        {
            throw new Exception($"Input value with label {label} is not a value");
        }

        if (!inputValueHandle.ValueType.Equals(valueType))
        {
            throw new Exception($"Input value with label {label} is not a {valueType}");
        }

        if (!inputValueHandle.GetValue().HasValue())
        {
            throw new InputValueWithNoValueException(label);
        }

        return inputValueHandle.GetValue().Cast<T>().Value;
    }

    public class InputValueWithNoValueException(string label)
        : Exception($"Input value with label {label} has no value");
}