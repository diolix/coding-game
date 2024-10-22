using GraphModel.NewHandle;
using GraphModel.Util;

namespace GraphModel.NewEdge;

public interface INewEdge
{
    ColorHex Color { get; }
    void Remove();
    bool Contains(INewHandle handle);
}