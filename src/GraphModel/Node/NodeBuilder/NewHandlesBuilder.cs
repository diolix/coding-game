using GraphModel.Handle;
using GraphModel.Node.BaseNodes;
using GraphModel.Util;

namespace GraphModel.Node.NodeBuilder;

public class NewHandlesBuilder
{
    private IList<NewHandleModel.Builder> _handlesBuilder;
    private int _index;
    
    public NewHandlesBuilder()
    {
        _handlesBuilder = new List<NewHandleModel.Builder>();
        _index = 0;
    }

    public void AddHandle(string label, ColorHex color)
    {
        _handlesBuilder.Add(new NewHandleModel.Builder()
            .SetLabel(label)
            .SetColor(color)
            .SetIndex(_index++));
    }
    
    public IList<IHandle> BuildHandles(INode node)
    {
        return _handlesBuilder.Select(builder => builder.SetNode(node).Build()).ToArray();
    }
}