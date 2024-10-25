using GraphModel.Edge;
using GraphModel.Handle.Value.Output;
using GraphModel.NewValueTypes;
using GraphModel.Node;

namespace GraphModel.Handle.Value.Input;

public class InputValueHandle(string label, ValueTypeEnum valueTypeEnum, INode node) : BaseValueHandle(label, valueTypeEnum, node)
{
    public ValueEdge? Edge { private get; set; }
    public bool HasEdge => Edge != null;
    public bool IsOfType(ValueTypeEnum valueTypeEnum) => ValueTypeEnum.Equals(valueTypeEnum);

    protected override bool IsCompatible(IHandle handle)
    {
        return handle is BaseOutputValueHandle outputValueHandle &&
               outputValueHandle.ValueTypeEnum.Equals(ValueTypeEnum);
    }

    public override NewValueTypes.Value GetValue() => Edge?.GetOutputValue() ?? ValueFactory.CreateValue(ValueTypeEnum);
}