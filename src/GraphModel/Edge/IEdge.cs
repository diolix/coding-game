using GraphModel.Handle;
using GraphModel.NewHandle;

namespace GraphModel.Edge;
public interface IEdge
{ 
    IHandle To { get; }
    IHandle From { get; }
}