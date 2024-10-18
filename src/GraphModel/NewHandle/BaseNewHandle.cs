using GraphModel.Util;

namespace GraphModel.NewHandle;

public abstract class BaseNewHandle : INewHandle
{
    public string Label { get; }
    public abstract ColorHex Color { get; }
    
    public abstract bool IsCompatible(INewHandle handle);
    
    public BaseNewHandle(string label)
    {
        Label = label;
    }
}