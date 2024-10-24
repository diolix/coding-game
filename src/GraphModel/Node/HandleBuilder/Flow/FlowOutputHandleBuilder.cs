using GraphModel.Handle.Flow;

namespace GraphModel.Node.HandleBuilder.Flow;

public class FlowOutputHandleBuilder : BaseFlowHandleBuilder
{
    public override IEnumerable<OutputFlowHandle> Build(INode node) => HandlesLabel.Select(label =>
        new OutputFlowHandle(label, node));
}