using CodingGame.Script.Util;
using GraphModel.Node.Input;
using GraphModel.Node.Output;

namespace GraphModel.Node.NodeBuilder;

public class HandlesExecution
{
    private InputManager _inputManager;
    private OutputManager _outputManager;
    private Action _onLastExecution;
    
    public HandlesExecution(InputManager inputManager, OutputManager outputManager, Action onLastExecution)
    {
        _inputManager = inputManager;
        _outputManager = outputManager;
        _onLastExecution = onLastExecution;
    }
    
    public Optional<string> GetStringInputValue(int index) => GetInputValue<string>(index);
    public Optional<int> GetIntInputValue(int index) => GetInputValue<int>(index);
    public Optional<bool> GetBoolInputValue(int index) => GetInputValue<bool>(index);
    private Optional<T> GetInputValue<T>(int index)
    {
        var objectValue = _inputManager.SafeGetInputValue(index);
        if (!objectValue.HasValue()) return new Optional<T>();
        
        if (objectValue.Value is T b) return new Optional<T>(b);
        return new Optional<T>();
    }
    
    public void SafeExecute(int index)
    {
        if (!_outputManager.SafeExecuteFlowOutput(index)) _onLastExecution?.Invoke();
    }
    
    public void SetOutputValue(int outputIndex, object value)
    {
        _outputManager.SetValue(outputIndex, value);
    }
}