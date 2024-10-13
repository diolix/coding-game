using GraphModel.Util;

namespace GraphModel.NewHandle.Implementation;

public class OutputValueHandle : BaseNewHandle
{
    public OutputValueHandle(string label, ExecutionContext executionContext) : base(label, executionContext)
    {
    }

    public override ColorHex Color { get; }
    public override bool IsCompatible(INewHandle handle)
    {
        throw new NotImplementedException();
    }

    public void Execute()
    {
        throw new NotImplementedException();
    }

    public ValueType ValueType { get; }
}