using GraphModel.Handle;

namespace GraphModel.Edge;
public interface IEdge
{ 
    IHandle To { get; }
    IHandle From { get; }
}