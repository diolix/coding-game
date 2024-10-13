using GraphModel.NewHandle.Interfaces;
using GraphModel.Util;

namespace GraphModel.NewHandle.Implementation.Flow;

public class InputFlowHandle : BaseNewHandle, IInputNewHandle, IFlowNewHandle
{
    public InputFlowHandle(string label, ExecutionContext executionContext) : base(label, executionContext)
    {
    }

    public override ColorHex Color { get; }
    public override bool IsCompatible(INewHandle handle)
    {
        throw new NotImplementedException();
    }

    public object GetValue()
    {
        throw new NotImplementedException();
    }
}