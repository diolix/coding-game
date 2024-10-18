using GraphModel.NewHandle;
using GraphModel.NewHandle.Flow;
using GraphModel.NewHandle.Value.Impure;
using ExecutionContext = GraphModel.NewHandle.Flow.ExecutionContext;

namespace GraphModel.Node;

public class NewHandlesBuilder
{
    private ExecutionContext _executionContext;
    
    private IList<INewHandle> _inputHandles;
    public IEnumerable<INewHandle> InputHandles => _inputHandles;
    
    private IList<INewHandle> _outputHandles;
    public IEnumerable<INewHandle> OutputHandles => _outputHandles;
    
    public NewHandlesBuilder(ExecutionContext executionContext)
    {
        _executionContext = executionContext;
    }

    public void AddInputFlowHandle(string label)
    {
        var handle = new InputFlowHandle(label, _executionContext);
        _inputHandles.Add(handle);
    }
    
    public void AddInputValueHandle(string label, ValueType type)
    {
        var handle = new ImpureInputValueHandle(label, type);
        _inputHandles.Add(handle);
    }
    
    public void AddOutputFlowHandle(string label)
    {
        var handle = new OutputFlowHandle(label);
        _outputHandles.Add(handle);
    }
    
    public void AddOutputValueHandle(string label, ValueType type)
    {
        var handle = new ImpureOutputValueHandle(label, type);
        _outputHandles.Add(handle);
    }
}