using GraphModel.Handle.Value;
using GraphModel.Values;

namespace GraphModel.Node.HandleBuilder.Value;

public abstract class BaseValueHandleBuilder
{
    protected List<ValueHandleValues> HandlesValues { get; } = new();
    protected record ValueHandleValues(string Label, ValueTypeEnum ValueType);
    
    public void AddValueHandle(string label, ValueTypeEnum type) => HandlesValues.Add(new ValueHandleValues(label, type));
    public abstract IEnumerable<BaseValueHandle> Build(INode node);
}