using GraphModel.Handle.Flow;

namespace GraphModel.Node.HandleBuilder.Flow;

public class FlowInputHandleBuilder : BaseFlowHandleBuilder
{
    public override IEnumerable<BaseFlowHandle> Build(INode node) => HandlesLabel.Select(label =>
        new InputFlowHandle(label, node));
}