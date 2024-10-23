using GraphModel.Node;

namespace GraphModel.Handle.Flow;

public class InputFlowHandle(string label, INode node) : BaseFlowHandle(label, node)
{
    protected override bool IsCompatible(IHandle handle) => handle is OutputFlowHandle;
    
    public void Execute() => Node.Execute();
}