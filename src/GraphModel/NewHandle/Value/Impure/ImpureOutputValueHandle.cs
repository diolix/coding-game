using CodingGame.Script.Util;
using GraphModel.Util;

namespace GraphModel.NewHandle.Value.Impure;

public class ImpureOutputValueHandle : BaseNewHandle
{
    public ValueType ValueType { get; }
    private Optional<object> _cachedValue;
    public ImpureOutputValueHandle(string label, ValueType valueType) : base(label)
    {
        _cachedValue = new Optional<object>();
        Color = valueType.GetColor();
        ValueType = valueType;
    }

    public override ColorHex Color { get; }

    public override bool IsCompatible(INewHandle handle) => handle is ImpureInputValueHandle inputValueHandle &&
                                                            inputValueHandle.ValueType.Equals(ValueType);
    
    public void SetCachedValue(object value) => _cachedValue = new Optional<object>(value);
    public Optional<object> GetCachedValue() => _cachedValue;
}