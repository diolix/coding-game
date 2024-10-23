using GraphModel.Handle;

namespace GraphModel.Node.HandleBuilder.Pure;

public abstract class BasePureHandleBuilder
{
    protected readonly IList<ValueHandleValues> HandlesValues = new List<ValueHandleValues>();
    public void AddValueHandle(string label, ValueType type) => HandlesValues.Add(new ValueHandleValues(label, type));
    public abstract IEnumerable<IHandle> Build(INode node);
}