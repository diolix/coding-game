using GraphModel.Util;

namespace GraphModel.Handle.Flow;

public abstract class BaseFlowHandle : BaseHandle
{
    protected BaseFlowHandle(string label) : base(label)
    {
    }

    public override ColorHex Color => new(System.Drawing.Color.White);
}