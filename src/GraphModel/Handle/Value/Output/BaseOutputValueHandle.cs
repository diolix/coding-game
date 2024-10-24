using GraphModel.Handle.Value.Input;
using GraphModel.Node;
using GraphModel.Util;

namespace GraphModel.Handle.Value.Output;

public abstract class BaseOutputValueHandle(string label, ValueType valueType, INode node) : BaseValueHandle(label, valueType, node)
{
    protected Optional<object> CachedValue = new();

    protected override bool IsCompatible(IHandle handle) => handle is InputValueHandle inputValueHandle &&
                                                         inputValueHandle.ValueType.Equals(ValueType);
    
    public void SetCachedValue(object value){
        CachedValue = new Optional<object>(value);
    }
}