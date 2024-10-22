using CodingGame.Script.Util;

namespace GraphModel.Handle.Value;

public class ImpureOutputValueHandle : BaseOutputValueHandle
{
    public ImpureOutputValueHandle(string label, ValueType valueType) : base(label, valueType)
    {
    }

    public override Optional<object> GetCachedValue() => CachedValue;
}