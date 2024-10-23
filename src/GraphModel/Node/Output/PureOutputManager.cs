using GraphModel.Handle;
using GraphModel.Handle.Value;
using GraphModel.Handle.Value.Output;

namespace GraphModel.Node.Output;

public class PureOutputManager
{
    private readonly IEnumerable<IHandle> _handles;
    
    private IEnumerable<PureOutputValueHandle> _outputValueHandles = null!; 
    
    public PureOutputManager(IEnumerable<IHandle> handles)
    {
        _handles = handles;
        InitializeOutputValueHandles();
    }

    private void InitializeOutputValueHandles()
    {
        _outputValueHandles = _handles.OfType<PureOutputValueHandle>();
    }
    
    public void CacheValue(string label, object value)
    {
        _outputValueHandles.First(handle => handle.Label == label).SetCachedValue(value);
    }
}