using GraphModel.NewHandle;
using GraphModel.NewHandle.Flow;
using GraphModel.NewHandle.Value;

namespace GraphModel.Node.HandleBuilder;

public class ImpureOutputHandlesBuilder
{
    private readonly IList<INewHandle> _outputHandles;

    public ImpureOutputHandlesBuilder()
    {
        _outputHandles = new List<INewHandle>();
    }

    public IEnumerable<INewHandle> OutputHandles => _outputHandles;
    
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