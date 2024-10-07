using GraphModel.Handle;
using GraphModel.NewHandle;
using GraphModel.Util;

namespace GraphModel.Node;

public class HandlesBuilder
{
    private IList<NewHandleValueModel.HandleValueBuilder?> _valueHandlesBuilder;
    private IList<NewHandleFlowModel.HandleFlowBuilder?> _flowHandlesBuilder;
    private int _index;
    
    public HandlesBuilder()
    {
        _valueHandlesBuilder = new List<NewHandleValueModel.HandleValueBuilder?>();
        _flowHandlesBuilder = new List<NewHandleFlowModel.HandleFlowBuilder?>();
        _index = 0;
    }

    public void AddFlow(string label)
    {
        _valueHandlesBuilder.Add(null);
        var test = new NewHandleFlowModel.HandleFlowBuilder()
            .SetLabel(label)
            .SetIndex(_index++);
        _flowHandlesBuilder.Add(test);
    }

    public void AddValue(string label, ValueType type)
    {
        _flowHandlesBuilder.Add(null);
        var test = new NewHandleValueModel.HandleValueBuilder()
            .SetLabel(label)
            .SetIndex(_index++)
            .SetType(type);
        _valueHandlesBuilder.Add(test);
        
    }
    
    public IList<IHandle> BuildHandles(INode node)
    {
        var res = new List<IHandle>();
        
        var highestCount = Math.Max(_valueHandlesBuilder.Count, _flowHandlesBuilder.Count);
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