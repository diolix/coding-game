using System.Drawing;
using GraphModel.Handle.HandleFlow;
using GraphModel.Node.BaseNodes;
using GraphModel.Util;

namespace GraphModel.NewHandle;

public class NewHandleFlowModel : NewHandleModel, IHandleFlow
{
    public override ColorHex Color { get; } = new(System.Drawing.Color.White);

    private NewHandleFlowModel(string label, int index, INode node) : base(label, index, node) { }
    
    public new class Builder : NewHandleModel.Builder
    {
        public override NewHandleModel Build()
        {
            return new NewHandleFlowModel(Label, Index, Node);
        }
    }
}