using GraphModel.Edge;
using GraphModel.Handle;

namespace GraphModel.Node.Output;

public interface IOutputManager
{
    public IList<IHandle> Handles { get; }
    public void AddEdge(IEdge edge);
    public void RemoveEdge(IEdge outputHandle);
}