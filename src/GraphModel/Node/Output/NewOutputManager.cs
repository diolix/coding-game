using GraphModel.NewHandle;
using GraphModel.NewHandle.Flow;
using GraphModel.NewHandle.Value;
using GraphModel.NewHandle.Value.Impure;

namespace GraphModel.Node.Output;

public class NewOutputManager
{
    private readonly IEnumerable<INewHandle> _handles;
    public IEnumerable<INewHandle> Handles => _handles;
    
    private IEnumerable<OutputFlowHandle> _outputFlowHandles;
    
    private IEnumerable<ImpureOutputValueHandle> _outputValueHandles; 
    
    public NewOutputManager(IEnumerable<INewHandle> handles)
    {
        _handles = handles;
        InitializeOutputFlowHandles();
        InitializeOutputValueHandles();
    }

    private void InitializeOutputFlowHandles()
    {
        _outputFlowHandles = _handles.Where(handle => handle is OutputFlowHandle).Cast<OutputFlowHandle>();
    }

    private void InitializeOutputValueHandles()
    {
        _outputValueHandles = _handles.Where(handle => handle is ImpureOutputValueHandle).Cast<ImpureOutputValueHandle>();
    }

    public void ExecuteFlowOutput(string label)
    {
        _outputFlowHandles.First(handle => handle.Label == label).SentExecutionFlow();
    }
    
    public void CacheOutputValue(string label, object value)
    {
        _outputValueHandles.First(handle => handle.Label == label).SetCachedValue(value);
    }
}