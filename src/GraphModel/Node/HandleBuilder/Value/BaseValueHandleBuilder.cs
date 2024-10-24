using GraphModel.Handle.Value;

namespace GraphModel.Node.HandleBuilder.Value;

public abstract class BaseValueHandleBuilder
{
    protected List<ValueHandleValues> HandlesValues { get; } = new();
    protected record ValueHandleValues(string Label, ValueType ValueType);
    
    public void AddValueHandle(string label, ValueType type) => HandlesValues.Add(new ValueHandleValues(label, type));
    public abstract IEnumerable<BaseValueHandle> Build(INode node);
}