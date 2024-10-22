using GraphModel.Handle;
using GraphModel.Handle.Flow;
using GraphModel.Handle.Value;

namespace GraphModel.Node.HandleBuilder;

public class ImpureOutputHandlesBuilder
{
    private readonly IList<IHandle> _outputHandles;

    public ImpureOutputHandlesBuilder()
    {
        _outputHandles = new List<IHandle>();
    }

    public IEnumerable<IHandle> OutputHandles => _outputHandles;
    
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