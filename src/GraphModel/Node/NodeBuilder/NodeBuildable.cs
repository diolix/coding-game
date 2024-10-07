using GraphModel.Node.Input;
using GraphModel.Node.Output;

namespace GraphModel.Node.NodeBuilder;

public partial class NodeBuildable : INode
{
    public string Name { get; private set; } = string.Empty;
    public bool IsPure { get; private set; }
    public event Action? OnStartExecution;
    public event Action? OnFinishedExecution;
    public IOutputManager Output { get; private set; } = null!;
    public IInputManager Input { get; private set; } = null!;
    private HandlesExecution _handlesExecution = null!;
    private Action<HandlesExecution> _execution = null!;
    
    private protected NodeBuildable(){}
    
    public void Execute()
    {
        OnStartExecution?.Invoke();
        _execution(_handlesExecution);
        OnFinishedExecution?.Invoke();
    }
}