using GraphModel.Node;
using GraphModel.Util;

namespace GraphModel.Handle.Flow;

public class BaseHandleFlowModel : BaseHandleModel, IHandleFlow
{
    public override ColorHex Color { get; } = new(System.Drawing.Color.White);

    private BaseHandleFlowModel(string label, int index, INode node) : base(label, index, node) { }
    
    public class HandleFlowBuilder : Builder<HandleFlowBuilder>
    {
        protected override HandleFlowBuilder This => this;

        public override BaseHandleModel Build()
        {
            return new BaseHandleFlowModel(Label, Index, Node);
        }
    }
}