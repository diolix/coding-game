using GraphModel.Util;

namespace GraphModel.NewHandle;

public interface INewHandle
{
    public string Label { get;}
    public ColorHex Color { get; }
    public bool IsCompatible(INewHandle handle);
    public void AddEdge(NewEdge.NewEdge edge);
    public void RemoveEdge(NewEdge.NewEdge edge);
}