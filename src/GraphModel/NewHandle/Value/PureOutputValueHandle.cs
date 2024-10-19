using CodingGame.Script.Util;

namespace GraphModel.NewHandle.Value;

public class PureOutputValueHandle : BaseOutputValueHandle
{
    private readonly ExecutionContext _executionContext;
    public PureOutputValueHandle(string label, ValueType valueType, ExecutionContext executionContext) : base(label, valueType)
    {
        _executionContext = executionContext;
    }

    public override Optional<object> GetCachedValue()
    {
        _executionContext.Execute();
        return CachedValue;
    }
}