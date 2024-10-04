using CodingGame.Script.Graph.Model.Handle;
using CodingGame.Script.Graph.Model.Node.BaseNodes;
using GraphModel.Node.BaseNodes;
using GraphModel.Util;

namespace GraphModel.Handle;

public abstract class HandleModel : IHandle
{
    public string Label { get; set; }
    public INode Node { get; set; }
    public int Index { get; set; }
    public abstract ColorHex Color { get; }
    public abstract bool IsCompatible(IHandle handle);

    public HandleModel(string label, int index, INode node)
    {
        Label = label;
        Node = node;
        Index = index;
    }
}