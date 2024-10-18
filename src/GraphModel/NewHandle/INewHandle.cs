using GraphModel.Util;

namespace GraphModel.NewHandle;

public interface INewHandle
{
    public string Label { get;}
    public ColorHex Color { get; }
    public bool IsCompatible(INewHandle handle);
}