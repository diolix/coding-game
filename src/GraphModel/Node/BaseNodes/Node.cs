using System;
using GraphModel.Node.BaseNodes;
using GraphModel.Node.Input;
using GraphModel.Node.Output;

namespace CodingGame.Script.Graph.Model.Node.BaseNodes;

public abstract class Node : INode
{
    public abstract string Name { get; }
    public abstract bool IsPure { get;}
    public abstract IOutputManager Output { get; }
    public abstract IInputManager Input { get; }
    public abstract void Execute();
    public abstract void Configure();
    public event Action OnLastExecution;
    protected void InvokeOnLastExecution() => OnLastExecution?.Invoke();
}