using GraphModel.Handle;
using GraphModel.Util;

namespace GraphModel.Edge;

public interface IEdge
{
    ColorHex Color { get; }
    void Remove();
    bool Contains(IHandle handle);
}