using GraphModel.NewHandle;

namespace GraphModel.NewEdge;

public class NewEdge
{
    protected INewHandle From;
    protected INewHandle To;

    internal NewEdge(INewHandle from, INewHandle to)
    {
        if (!From.IsCompatible(to))
            throw new Exception("Incompatible handles");
        
        From = from;
        To = to;
    }
    
    public void RemoveFromHandles()
    {
        From.RemoveEdge(this);
        To.RemoveEdge(this);
    }
    
    public bool Contain(INewHandle handle)
    {
        return From == handle || To == handle;
    }
}