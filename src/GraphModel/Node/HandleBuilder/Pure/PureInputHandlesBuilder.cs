using GraphModel.Handle;
using GraphModel.Handle.Value;

namespace GraphModel.Node.HandleBuilder.Pure;

public class PureInputHandlesBuilder : BasePureHandleBuilder
{
    public override IEnumerable<IHandle> Build(INode node) => HandlesValues.Select(valueHandleValues =>
        new InputValueHandle(valueHandleValues.Label, valueHandleValues.ValueType, node)).ToList();
}