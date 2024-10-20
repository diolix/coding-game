using GraphModel.NewHandle;
using GraphModel.NewHandle.Flow;
using GraphModel.NewHandle.Value;

namespace GraphModel.Node.Output;

public class NewImpureOutputManager
{
    private readonly IEnumerable<INewHandle> _handles;
    public IEnumerable<INewHandle> Handles => _handles;
    
    private IEnumerable<OutputFlowHandle> _outputFlowHandles = null!;
    
    private IEnumerable<ImpureOutputValueHandle> _outputValueHandles = null!; 
    
    public NewImpureOutputManager(IEnumerable<INewHandle> handles)
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