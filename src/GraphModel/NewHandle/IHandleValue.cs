using GraphModel.Handle;

namespace GraphModel.NewHandle;

public interface IHandleValue : IHandle
{
    public ValueType Type { get; }
}