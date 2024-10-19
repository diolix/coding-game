using GraphModel.NewHandle;
using GraphModel.NewHandle.Value;
using ExecutionContext = GraphModel.NewHandle.ExecutionContext;

namespace GraphModel.Node.HandleBuilder;

public class PureOutputHandlesBuilder
{
    private readonly IList<INewHandle> _outputHandles;
    private readonly ExecutionContext _executionContext;

    public PureOutputHandlesBuilder(ExecutionContext executionContext)
    {
        _outputHandles = new List<INewHandle>();
        _executionContext = executionContext;
    }

    public IEnumerable<INewHandle> OutputHandles => _outputHandles;
    
    public void AddOutputValueHandle(string label, ValueType type)
    {
        var handle = new PureOutputValueHandle(label, type, _executionContext);
        _outputHandles.Add(handle);
    }
}