namespace GraphModel.Handle.Value;

public interface IHandleValue : IHandle
{
    public ValueType Type { get; }
}