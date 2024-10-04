using CodingGame.Script.Graph.Model.Node.BaseNodes;
using GraphModel.Node.BaseNodes;
using GraphModel.Util;

namespace GraphModel.Handle;

public interface IHandle
{
    public string Label { get; }
    public int Index { get; }
    public INode Node { get; }
    public ColorHex Color { get; }
    public bool IsCompatible(IHandle handle);
}