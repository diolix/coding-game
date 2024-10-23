using GraphModel.Node;
using GraphModel.Util;

namespace GraphModel.Handle.Value.Output;

public abstract class BaseOutputValueHandle(string label, ValueType valueType, INode node) : BaseHandle(label, node)
{
    public ValueType ValueType { get; } = valueType;
    protected Optional<object> CachedValue = new();

    public override ColorHex Color { get; } = valueType.GetColor();

    protected override bool IsCompatible(IHandle handle) => handle is InputValueHandle inputValueHandle &&
                                                         inputValueHandle.ValueType.Equals(ValueType);
    
    public void SetCachedValue(object value){
        CachedValue = new Optional<object>(value);
    }
    public abstract Optional<object> GetCachedValue();
}