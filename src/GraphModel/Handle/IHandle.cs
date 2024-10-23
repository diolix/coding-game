using GraphModel.Node;
using GraphModel.Util;

namespace GraphModel.Handle;

public interface IHandle
{
    public string Label { get;}
    public ColorHex Color { get; }
    public bool IsCompatible(IHandle handle);
    public bool HasSameNode(INode handle);
}