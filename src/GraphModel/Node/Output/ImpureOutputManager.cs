using GraphModel.Handle;
using GraphModel.Handle.Flow;
using GraphModel.Handle.Value;

namespace GraphModel.Node.Output;

public class ImpureOutputManager
{
    private readonly IEnumerable<IHandle> _handles;
    
    private IEnumerable<OutputFlowHandle> _outputFlowHandles = null!;
    
    private IEnumerable<ImpureOutputValueHandle> _outputValueHandles = null!; 
    
    public ImpureOutputManager(IEnumerable<IHandle> handles)
    {
        _handles = handles;
        InitializeOutputFlowHandles();
        InitializeOutputValueHandles();
    }

    private void InitializeOutputFlowHandles()
    {
        _outputFlowHandles = _handles.OfType<OutputFlowHandle>();
    }

    private void InitializeOutputValueHandles()
    {
        _outputValueHandles = _handles.OfType<ImpureOutputValueHandle>();
    }

    public void Execute(string label)
    {
        _outputFlowHandles.First(handle => handle.Label == label).SentExecutionFlow();
    }
    
    public void CacheValue(string label, object value)
    {
        _outputValueHandles.First(handle => handle.Label == label).SetCachedValue(value);
    }
}