using GraphModel.NewHandle;

namespace GraphModel.Node.NodeBuilder.NewNode;

public partial class NewNodeBuildable : INewNode
{
    public string Name { get; private set; } = string.Empty;
    public event Action? OnStartExecution;
    public event Action? OnFinishedExecution;
    public IList<INewHandle> InputHandles { get; private set; } = null!;
    public IList<INewHandle> OutputHandles { get; private set; } = null!;
    private NewHandlesExecution _handlesExecution = null!;
    private Action<NewHandlesExecution> _execution = null!;
    
    private protected NewNodeBuildable(){}
    
    public void Execute()
    {
        OnStartExecution?.Invoke();
        _execution(_handlesExecution);
        OnFinishedExecution?.Invoke();
    }
}