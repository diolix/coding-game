using GraphModel.NewHandle;

namespace GraphModel.Node.NodeBuilder.NewNode;

public abstract partial class BaseNodeBuildable : INewNode
{
    public string Name { get; private set; } = string.Empty;
    public event Action? OnStartExecution;
    public event Action? OnFinishedExecution;
    public IList<INewHandle> InputHandles { get; private set; } = null!;
    public IList<INewHandle> OutputHandles { get; protected set; } = null!;
    
    protected BaseNodeBuildable(){}

    public void Execute()
    {
        OnStartExecution?.Invoke();
        ExecuteWithHandlesContext();
        OnFinishedExecution?.Invoke();
    }
    
    protected abstract void ExecuteWithHandlesContext();
}