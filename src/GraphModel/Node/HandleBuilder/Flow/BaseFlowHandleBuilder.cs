using GraphModel.Handle.Flow;

namespace GraphModel.Node.HandleBuilder.Flow;

public abstract class BaseFlowHandleBuilder
{
    protected List<string> HandlesLabel { get; } = new();
    public void AddFlowHandle(string label) => HandlesLabel.Add(label);
    public abstract IEnumerable<BaseFlowHandle> Build(INode node);
}