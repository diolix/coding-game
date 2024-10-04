using GraphModel.Handle;
using ValueType = GraphModel.ValueType;

namespace CodingGame.Script.Graph.Model.Handle.HandleValue;

public interface IHandleValue : IHandle
{
    public ValueType Type { get; }
}