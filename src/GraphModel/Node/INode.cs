using GraphModel.Handle;

namespace GraphModel.Node;

public interface INode
{
    public string? Name { get; }
    public void Execute();
    public event Action? OnStartExecution;
    public event Action? OnFinishedExecution;
    public IEnumerable<IHandle> Inputs { get; }
    public IEnumerable<IHandle> Outputs { get; }
    public IHandle GetInputHandle(string label);
    public IHandle GetOutputHandle(string label);
}