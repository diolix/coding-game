using GraphModel.Edge;
using GraphModel.Handle.Value.Output;
using GraphModel.Node;
using GraphModel.Util;

namespace GraphModel.Handle.Value.Input;

public class InputValueHandle(string label, ValueType valueType, INode node) : BaseValueHandle(label, valueType, node)
{
    public ValueEdge? Edge { private get; set; }
    public bool HasEdge => Edge != null;
    protected override bool IsCompatible(IHandle handle)
    {
        return handle is BaseOutputValueHandle outputValueHandle &&
               outputValueHandle.ValueType.Equals(ValueType);
    }

    public override Optional<object> GetValue()
    {
        return Edge is null ? new Optional<object>() : Edge.GetOutputValue();
    }

}