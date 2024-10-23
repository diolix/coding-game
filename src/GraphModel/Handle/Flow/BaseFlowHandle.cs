using GraphModel.Node;
using GraphModel.Util;

namespace GraphModel.Handle.Flow;

public abstract class BaseFlowHandle(string label, INode node) : BaseHandle(label, node)
{
    public override ColorHex Color => new(System.Drawing.Color.White);
}