using GraphModel.Handle;

namespace GraphModel.Node.HandleBuilder.Impure;

public abstract class BaseImpureHandleBuilder
{
    protected readonly IList<HandleValues> HandlesValues = new List<HandleValues>();
    
    public void AddFlowHanlde(string label) => HandlesValues.Add(new FlowHandleValues(label));
    
    public void AddValueHandle(string label, ValueType type) => HandlesValues.Add(new ValueHandleValues(label, type));
    public abstract IEnumerable<IHandle> Build(INode node);
}