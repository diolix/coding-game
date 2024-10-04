using CodingGame.Script.Util;
using GraphModel.Node;
using GraphModel.Node.Input;
using GraphModel.Node.Output;
using ValueType = GraphModel.ValueType;

namespace CodingGame.Script.Graph.Model.Node.BaseNodes;

public abstract class PrimitiveNode : Node
{
    public override IOutputManager Output => _outputsManager;
    public override IInputManager Input => _inputManager;
    private bool _isPure;
    public override bool IsPure => _isPure;
    protected HandlesConstructor InputsConstructor { get; }
    protected HandlesConstructor OutputsConstructor { get; }
    
    private OutputManager _outputsManager;
    private InputManager _inputManager;
    public PrimitiveNode()
    {
        InputsConstructor = new HandlesConstructor(this);
        OutputsConstructor = new HandlesConstructor(this);
    }

    public override void Configure()
    {
        ConfigureHandle();
        _outputsManager = new OutputManager(OutputsConstructor.GetHandles());
        _inputManager = new InputManager(InputsConstructor.GetHandles());
    }

    protected abstract void ConfigureHandle();
    
    // helper Execute
    protected void SafeExecute(int index)
    {
        if (!_outputsManager.SafeExecuteFlowOutput(index)) InvokeOnLastExecution();
    }
    
    protected void SetOutputValue(int outputIndex, object value)
    {
        _outputsManager.SetValue(outputIndex, value);
    }
    
    protected Optional<T> GetInputValue<T>(int index)
    {
        var objectValue = _inputManager.SafeGetInputValue(index);
        if (!objectValue.HasValue()) return new Optional<T>();
        
        if (objectValue.Value is T b) return new Optional<T>(b);
        return new Optional<T>();
    }
    
    protected Optional<object> GetInputValue(int index, ValueType type)
    {
        if (type.Equals(ValueType.AnyValue)) return _inputManager.SafeGetInputValue(index);
        if (type.Equals(ValueType.Int)) return GetInputValue<int>(index).Cast<object>();
        if (type.Equals(ValueType.String)) return GetInputValue<string>(index).Cast<object>();
        if (type.Equals(ValueType.Bool)) return GetInputValue<bool>(index).Cast<object>();
        
        return new Optional<object>();
    }
    
    protected void SetPure(bool isPure) => _isPure = isPure;
    
}