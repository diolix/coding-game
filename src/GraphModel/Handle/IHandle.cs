using GraphModel.Edge;
using GraphModel.Node;
using GraphModel.Util;

namespace GraphModel.Handle;

public interface IHandle
{
    public string Label { get;}
    public INode Node { get; }
    public Action OnExecute { get; }
    public int Index { get; }
    public ColorHex Color { get; }
    public bool IsCompatible(IHandle handle);
}