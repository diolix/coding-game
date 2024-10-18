using GraphModel.Util;

namespace GraphModel.NewHandle.Flow;

public abstract class BaseFlowHandle : BaseNewHandle
{
    protected BaseFlowHandle(string label) : base(label)
    {
    }

    public override ColorHex Color => new(System.Drawing.Color.White);
}