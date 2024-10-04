using GraphModel.Handle;
using GraphModel.Handle.HandleFlow;
using GraphModel.Handle.HandleValue;
using GraphModel.Node.BaseNodes;

namespace GraphModel.Node;

public class HandlesConstructor
{
    private readonly IList<IHandle> _handles;
    private readonly INode _node;
    private int _index;

    public IList<IHandle> GetHandles() => _handles;
    
    public HandlesConstructor(INode node)
    {
        _node = node;
        _handles = new List<IHandle>();
    }

    public void AddFlow(string label) => _handles.Add(CreateHandleFlow(label));
    private IHandle CreateHandleFlow(string label) => new HandleFlowModel(label, _index++, _node);
    
    public void AddValue(string label, ValueType type) => _handles.Add(CreateHandleValue(label, type));
    private IHandle CreateHandleValue(string label, ValueType type) =>
        new HandleValueModel(label, _index++, _node, type);
}