using GraphModel.Node;

namespace GraphModel.Handle.Flow;

public class InputFlowHandle : BaseFlowHandle
{
    private INewNode _node;
    public InputFlowHandle(string label, INewNode node) : base(label)
    {
        _node = node;
    }
    public override bool IsCompatible(IHandle handle)
    {
        return handle is OutputFlowHandle;
    }
    
    public void Execute()
    {
        _node.Execute();
    }
}