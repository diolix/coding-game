using GraphModel.Handle;
using GraphModel.NewHandle;
using GraphModel.Node.BaseNodes;
using GraphModel.Util;

namespace GraphModel.Node;

public class NewHandlesBuilder
{
    private IList<NewHandleModel.Builder> _handlesBuilder;
    private int _index;
    
    public NewHandlesBuilder()
    {
        _handlesBuilder = new List<NewHandleModel.Builder>();
        _index = 0;
    }

    public void AddFlow(string label)
    {
        _handlesBuilder.Add(new NewHandleFlowModel.Builder()
            .SetLabel(label)
            .SetIndex(_index++));
    }

    public void AddValue(string label, ValueType type)
    {
        var test = new NewHandleValueModel.Builder();
        
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