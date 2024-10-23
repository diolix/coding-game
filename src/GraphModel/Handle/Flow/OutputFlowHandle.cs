using GraphModel.Edge;
using GraphModel.Node;

namespace GraphModel.Handle.Flow;

public class OutputFlowHandle(string label, INode node) : BaseFlowHandle(label, node)
{
    public FlowEdge? FlowEdge { private get; set; }

    protected override bool IsCompatible(IHandle handle) => handle is InputFlowHandle;

    public void SentExecutionFlow() => FlowEdge?.ExecuteInputFlow();
}