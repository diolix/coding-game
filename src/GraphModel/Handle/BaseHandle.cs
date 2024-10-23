using GraphModel.Node;
using GraphModel.Util;

namespace GraphModel.Handle;

public abstract class BaseHandle(string label, INode node) : IHandle
{
    public string Label { get; } = label;
    public abstract ColorHex Color { get; }
    protected INode Node { get; } = node;

    protected abstract bool IsCompatible(IHandle handle);

    public bool HasSameNode(INode node) => node.Equals(Node);

    bool IHandle.IsCompatible(IHandle handle) => !handle.HasSameNode(Node) && IsCompatible(handle);
}