using CodingGame.Script.Util;
using GraphModel.Util;

namespace GraphModel.Handle.Value;

public abstract class BaseOutputValueHandle : BaseHandle
{
    public ValueType ValueType { get; }
    protected Optional<object> CachedValue;
    public BaseOutputValueHandle(string label, ValueType valueType) : base(label)
    {
        CachedValue = new Optional<object>();
        Color = valueType.GetColor();
        ValueType = valueType;
    }

    public override ColorHex Color { get; }

    public override bool IsCompatible(IHandle handle) => handle is InputValueHandle inputValueHandle &&
                                                            inputValueHandle.ValueType.Equals(ValueType);
    
    public void SetCachedValue(object value){
        CachedValue = new Optional<object>(value);
    }
    public abstract Optional<object> GetCachedValue();
}