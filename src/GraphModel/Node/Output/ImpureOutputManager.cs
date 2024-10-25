using GraphModel.Handle.Flow;
using GraphModel.Handle.Value.Output;
using GraphModel.NewValueTypes;

namespace GraphModel.Node.Output;

public class ImpureOutputManager(
    IEnumerable<ImpureOutputValueHandle> outputValues,
    IEnumerable<OutputFlowHandle> outputFlowHandles)
{
    private readonly OutputValueManager _outputValueManager = new(outputValues);
    private readonly FlowOutputManager _outputFlowHandles = new(outputFlowHandles);

    public void Cache(string label, Value value) =>
        _outputValueManager.Cache(label, value);

    public void Cache(string label, object value, ValueTypeEnum type) =>
        _outputValueManager.Cache(label, value, type);

    public void CacheString(string label, string value) =>
        _outputValueManager.CacheString(label, value);

    public void CacheBool(string label, bool value) =>
        _outputValueManager.CacheBool(label, value);

    public void CacheObject(string label, int value) =>
        _outputValueManager.CacheObject(label, value);

    public void Execute(string label) => _outputFlowHandles.Execute(label);
}