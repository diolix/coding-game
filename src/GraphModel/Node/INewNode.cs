using GraphModel.NewHandle;

namespace GraphModel.Node;

public interface INewNode
{
    public string? Name { get; }
    public void Execute();
    public event Action? OnStartExecution;
    public event Action? OnFinishedExecution;
    public IEnumerable<INewHandle> Inputs { get; }
    public IEnumerable<INewHandle> Outputs { get; }
    public INewHandle GetInputHandle(string label);
    public INewHandle GetOutputHandle(string label);
}