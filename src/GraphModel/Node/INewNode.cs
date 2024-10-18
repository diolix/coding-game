using GraphModel.NewHandle;

namespace GraphModel.Node;

public interface INewNode
{
    public string? Name { get; }
    public void Execute();
    public event Action? OnStartExecution;
    public event Action? OnFinishedExecution;
    public IEnumerable<INewHandle> InputHandles { get; }
    public IEnumerable<INewHandle> OutputHandles { get; }
}