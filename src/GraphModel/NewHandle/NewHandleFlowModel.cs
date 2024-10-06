using GraphModel.Handle.HandleFlow;
using GraphModel.Node.BaseNodes;
using GraphModel.Util;

namespace GraphModel.NewHandle;

public class NewHandleFlowModel : NewHandleModel, IHandleFlow
{
    public override ColorHex Color { get; } = new(System.Drawing.Color.White);

    private NewHandleFlowModel(string label, int index, INode node) : base(label, index, node) { }
    
    public class HandleFlowBuilder : Builder<HandleFlowBuilder>
    {
        protected override HandleFlowBuilder This => this;

        public override NewHandleModel Build()
        {
            return new NewHandleFlowModel(Label, Index, Node);
        }
    }
}