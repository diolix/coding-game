using CodingGame.Script.Graph.Model.Node.BaseNodes;
using GraphModel.Node.BaseNodes;
using GraphModel.Util;

namespace GraphModel.Handle.HandleFlow;

public class HandleFlowModel : HandleModel, IHandleFlow
{
    public HandleFlowModel(string label, int index, INode node) : base(label, index, node)
    { }

    public override ColorHex Color => new(System.Drawing.Color.White);
    public override bool IsCompatible(IHandle handle) => handle is IHandleFlow;
}