using GraphModel.NewEdge;
using GraphModel.Util;

namespace GraphModel.NewHandle.Flow;

public class InputFlowHandle : BaseFlowHandle
{
    private ExecutionContext _executionContext;
    public InputFlowHandle(string label, ExecutionContext executionContext) : base(label)
    {
        _executionContext = executionContext;
    }
    public override bool IsCompatible(INewHandle handle)
    {
        return handle is OutputFlowHandle;
    }
    
    public void Execute()
    {
        _executionContext.Execute();
    }
}