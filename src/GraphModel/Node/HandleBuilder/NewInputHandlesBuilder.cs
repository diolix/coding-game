using GraphModel.NewHandle;
using GraphModel.NewHandle.Flow;
using GraphModel.NewHandle.Value;
using ExecutionContext = GraphModel.NewHandle.ExecutionContext;

namespace GraphModel.Node.HandleBuilder;

public class NewInputHandlesBuilder
{
    private readonly ExecutionContext _executionContext;
    
    private readonly IList<INewHandle> _inputHandles;
    public IEnumerable<INewHandle> InputHandles => _inputHandles;
    
    public NewInputHandlesBuilder(ExecutionContext executionContext)
    {
        _executionContext = executionContext;
        _inputHandles = new List<INewHandle>();
    }

    public void AddInputFlowHandle(string label)
    {
        var handle = new InputFlowHandle(label, _executionContext);
        _inputHandles.Add(handle);
    }
    
    public void AddInputValueHandle(string label, ValueType type)
    {
        var handle = new InputValueHandle(label, type);
        _inputHandles.Add(handle);
    }
}