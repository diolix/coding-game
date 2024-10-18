using GraphModel.NewEdge;

namespace GraphModel.NewHandle.Flow;

public class OutputFlowHandle(string label) : BaseFlowHandle(label)
{
    public FlowEdge? FlowEdge { private get; set; }

    public override bool IsCompatible(INewHandle handle) => handle is InputFlowHandle;

    public void SentExecutionFlow()
    {
        FlowEdge?.ExecuteInputFlow();
    }
}