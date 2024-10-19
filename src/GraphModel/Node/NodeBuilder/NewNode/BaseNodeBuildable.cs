using GraphModel.NewHandle;

namespace GraphModel.Node.NodeBuilder.NewNode;

public abstract partial class BaseNodeBuildable : INewNode
{
    public string Name { get; private set; } = string.Empty;
    public event Action? OnStartExecution;
    public event Action? OnFinishedExecution;
    public IEnumerable<INewHandle> Inputs { get; private set; } = null!;
    public IEnumerable<INewHandle> Outputs { get; protected set; } = null!;
    public INewHandle GetInputHandle(string label) => Inputs.First(handle => handle.Label == label);

    public INewHandle GetOutputHandle(string label) => Outputs.First(handle => handle.Label == label);

    public void Execute()
    {
        OnStartExecution?.Invoke();
        ExecuteWithHandlesContext();
        OnFinishedExecution?.Invoke();
    }
    
    protected abstract void ExecuteWithHandlesContext();
}