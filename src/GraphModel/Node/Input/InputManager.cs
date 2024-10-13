using CodingGame.Script.Util;
using GraphModel.Handle;

namespace GraphModel.Node.Input;

public class InputManager : IInputManager
{
    private readonly InputValue[] _inputValues;
    private readonly IList<IHandle> _handles;
    
    public InputManager(IList<IHandle> handles)
    {
        _handles = handles;
        _inputValues = InputValue.CreateInputValues(handles.Count);
    }

    public IList<IHandle> Handles => _handles;

    public bool Set(int inputIndex, object value)
    {
        if (_inputValues.Length < inputIndex)
        {
            Console.Error.WriteLine("Input value index out of range.");
            return false;
        }

        _inputValues[inputIndex].SetValue(value);
        return true;
    }
    
    public bool SetPureNode(int inputIndex, INode value)
    {
        if (_inputValues.Length < inputIndex)
        {
            Console.Error.WriteLine("Input value index out of range.");
            return false;
        }

        _inputValues[inputIndex].SetPureNode(value);
        return true;
    }

    public bool ResetPureNode(int inputIndex)
    {
        if (_inputValues.Length < inputIndex)
        {
            Console.Error.WriteLine("Input value index out of range.");
            return false;
        }
        
        _inputValues[inputIndex].ResetPureNode();
        return true;
    }

    public void ResetValues()
    {
        foreach (var inputValue in _inputValues)
        {
            inputValue.ResetValue();
        }
    }
    
    public Optional<object> SafeGetInputValue(int index)
    {
        Optional<object> res = new();
        if (_inputValues.Length < index || _inputValues[index] == null)
            return res;
        
        return new (_inputValues[index].GetValue());
    }
}