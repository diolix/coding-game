using GraphModel.Handle;
using GraphModel.NewHandle;

namespace GraphModel.Edge;

public class EdgeModel : IEdge
{
    public IHandle From { get; }
    public IHandle To { get; }

    public EdgeModel(IHandle from, IHandle to)
    {
        From = from;
        To = to;
    }
}