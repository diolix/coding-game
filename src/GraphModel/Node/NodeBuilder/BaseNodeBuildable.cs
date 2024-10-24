using GraphModel.Handle;

namespace GraphModel.Node.NodeBuilder;

public abstract partial class BaseNodeBuildable : INode
{
    public string Name { get; private set; } = string.Empty;
    public event Action? OnStartExecution;
    public event Action? OnFinishedExecution;
    public IEnumerable<IHandle> Inputs { get; protected set; } = null!;
    public IEnumerable<IHandle> Outputs { get; protected set; } = null!;
    public IHandle GetInputHandle(string label) => Inputs.First(handle => handle.Label == label);

    public IHandle GetOutputHandle(string label) => Outputs.First(handle => handle.Label == label);

    public void Execute()
    {
        OnStartExecution?.Invoke();
        ExecuteWithHandlesContext();
        OnFinishedExecution?.Invoke();
    }
    
    protected abstract void ExecuteWithHandlesContext();
}