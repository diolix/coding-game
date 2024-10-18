using GraphModel.NewHandle;
using GraphModel.NewHandle.Flow;
using GraphModel.NewHandle.Value.Impure;
using ExecutionContext = GraphModel.NewHandle.Flow.ExecutionContext;

namespace GraphModel.Node.HandleBuilder;

public class NewInputHandlesBuilder
{
    private ExecutionContext _executionContext;
    
    private IList<INewHandle> _inputHandles;
    public IEnumerable<INewHandle> InputHandles => _inputHandles;
    
    public NewInputHandlesBuilder(ExecutionContext executionContext)
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
}