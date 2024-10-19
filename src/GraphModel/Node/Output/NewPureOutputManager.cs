using GraphModel.NewHandle;
using GraphModel.NewHandle.Value;

namespace GraphModel.Node.Output;

public class NewPureOutputManager
{
    private readonly IEnumerable<INewHandle> _handles;
    public IEnumerable<INewHandle> Handles => _handles;
    
    private IEnumerable<PureOutputValueHandle> _outputValueHandles = null!; 
    
    public NewPureOutputManager(IEnumerable<INewHandle> handles)
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