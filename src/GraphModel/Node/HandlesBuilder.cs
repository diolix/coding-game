using GraphModel.Handle;
using GraphModel.Handle.Flow;
using GraphModel.Handle.Value;

namespace GraphModel.Node;

public class HandlesBuilder
{
    private IList<BaseHandleValueModel.HandleValueBuilder?> _valueHandlesBuilder;
    private IList<BaseHandleFlowModel.HandleFlowBuilder?> _flowHandlesBuilder;
    private int _index;
    
    public HandlesBuilder()
    {
        _valueHandlesBuilder = new List<BaseHandleValueModel.HandleValueBuilder?>();
        _flowHandlesBuilder = new List<BaseHandleFlowModel.HandleFlowBuilder?>();
        _index = 0;
    }

    public void AddFlow(string label)
    {
        _valueHandlesBuilder.Add(null);
        var test = new BaseHandleFlowModel.HandleFlowBuilder()
            .SetLabel(label)
            .SetIndex(_index++);
        _flowHandlesBuilder.Add(test);
    }

    public void AddValue(string label, ValueType type)
    {
        _flowHandlesBuilder.Add(null);
        var test = new BaseHandleValueModel.HandleValueBuilder()
            .SetLabel(label)
            .SetIndex(_index++)
            .SetType(type);
        _valueHandlesBuilder.Add(test);
        
    }
    
    public IList<IHandle> BuildHandles(INode node)
    {
        var res = new List<IHandle>();
        
        for (int i = 0; i < _index; i++)
        {
            if(_valueHandlesBuilder[i] != null)
                res.Add(_valueHandlesBuilder[i]!.SetNode(node).Build());
            
            else if (_flowHandlesBuilder[i] != null) 
                res.Add(_flowHandlesBuilder[i]!.SetNode(node).Build());
        }
        
        return res;
    }
}