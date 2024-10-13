using GraphModel.Util;

namespace GraphModel.NewHandle.Implementation;

public abstract class BaseNewHandle : INewHandle
{
    public string Label { get; }
    public abstract ColorHex Color { get; }
    protected IList<NewEdge.NewEdge> Edges { get; } = new List<NewEdge.NewEdge>();
    protected ExecutionContext ExecutionContext { get; }
    public abstract bool IsCompatible(INewHandle handle);
    public void AddEdge(NewEdge.NewEdge edge) => Edges.Add(edge);
    public void RemoveEdge(NewEdge.NewEdge edge) => Edges.Remove(edge);
    
    public BaseNewHandle(string label, ExecutionContext executionContext)
    {
        Label = label;
        ExecutionContext = executionContext;
    }
}