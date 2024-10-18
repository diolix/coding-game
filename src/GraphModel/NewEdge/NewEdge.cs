using GraphModel.NewHandle;

namespace GraphModel.NewEdge;

public class NewEdge
{
    protected INewHandle From;
    protected INewHandle To;

    internal NewEdge(INewHandle from, INewHandle to)
    {
        if (!from.IsCompatible(to))
            throw new Exception("Incompatible handles");
        
        From = from;
        To = to;
    }
    
    public bool Contain(INewHandle handle)
    {
        return From == handle || To == handle;
    }
}