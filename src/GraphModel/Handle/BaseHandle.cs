using GraphModel.Util;

namespace GraphModel.Handle;

public abstract class BaseHandle : IHandle
{
    public string Label { get; }
    public abstract ColorHex Color { get; }
    
    public abstract bool IsCompatible(IHandle handle);
    
    public BaseHandle(string label)
    {
        Label = label;
    }
}