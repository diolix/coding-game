using GraphModel.Edge;

namespace GraphModel.Handle.Flow;

public class OutputFlowHandle(string label) : BaseFlowHandle(label)
{
    public FlowEdge? FlowEdge { private get; set; }

    public override bool IsCompatible(IHandle handle) => handle is InputFlowHandle;

    public void SentExecutionFlow()
    {
        FlowEdge?.ExecuteInputFlow();
    }
}