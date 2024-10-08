using GraphModel.Node.Input;
using GraphModel.Node.Output;

namespace GraphModel.Node;

public interface INode
{
    public string Name { get; }
    public bool IsPure { get; }
    public void Execute();
    public event Action? OnStartExecution;
    public event Action? OnFinishedExecution;
    public IOutputManager Output { get; }
    public IInputManager Input { get; }
}