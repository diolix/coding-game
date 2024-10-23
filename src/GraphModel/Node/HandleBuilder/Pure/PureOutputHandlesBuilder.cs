using GraphModel.Handle;
using GraphModel.Handle.Value;
using GraphModel.Handle.Value.Output;

namespace GraphModel.Node.HandleBuilder.Pure;

public class PureOutputHandlesBuilder : BasePureHandleBuilder
{
    public override IEnumerable<IHandle> Build(INode node) => HandlesValues.Select(valueHandleValues =>
        new PureOutputValueHandle(valueHandleValues.Label, valueHandleValues.ValueType, node)).ToList();
}