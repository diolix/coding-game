using CodingGame.Script.Util;

namespace GraphModel.Node.Input;

public class InputValue
{
    private Optional<object> _value = new();
    private INode? _pureNode;
    
    public static InputValue[] CreateInputValues(int count)
    {
        var res = new InputValue[count];
        for (int i = 0; i < count; i++)
        {
            res[i] = new InputValue();
        }

        return res;
    }
    
    public void SetValue(object value)
    {
        _value = new Optional<object>(value);
    }
    
    public void SetPureNode(INode node)
    {
        if (!node.IsPure) throw new Exception("Node is not pure.");
        _value = new Optional<object>();
        _pureNode = node;
    }
    
    public object GetValue()
    {
        return _pureNode != null ? GetValueFromPureNode() : GetValueFromObject();
    }

    private object GetValueFromObject()
    {
        return _value.Value;
    }

    private object GetValueFromPureNode()
    {
        _pureNode?.Execute();
        return _value.Value;
    }

    public void ResetValue()
    {
        _value = new Optional<object>();
    }
    
    public void ResetPureNode()
    {
        _pureNode = null;
    }
}