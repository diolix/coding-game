using CodingGame.Script.Util;
using GraphModel.Node.Input;
using GraphModel.Node.Output;

namespace GraphModel.Node.NodeBuilder.NewNode;

public class NewHandlesExecution
{
    private NewInputManager _inputManager;
    private NewOutputManager _outputManager;
    
    public NewHandlesExecution(NewInputManager inputManager, NewOutputManager outputManager)
    {
        _inputManager = inputManager;
        _outputManager = outputManager;
    }
    
    public Optional<object> GetInputValue(string label) => _inputManager.GetValue(label);
    public Optional<string> GetStringInputValue(string label) => GetInputValue<string>(label);
    public Optional<int> GetIntInputValue(string label) => GetInputValue<int>(label);
    public Optional<bool> GetBoolInputValue(string label) => GetInputValue<bool>(label);
    private Optional<T> GetInputValue<T>(string label)
    {
        var objectValue = _inputManager.GetValue(label);
        if (!objectValue.HasValue()) return new Optional<T>();
        
        if (objectValue.Value is T b) return new Optional<T>(b);
        return new Optional<T>();
    }
    
    public void SafeExecute(string label) =>
        _outputManager.ExecuteFlowOutput(label);
    
    public void CacheOutputValue(string outputlabel, object value) =>
        _outputManager.CacheOutputValue(outputlabel, value);
}