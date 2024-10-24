using GraphModel.Handle.Value.Output;

namespace GraphModel.Node.HandleBuilder.Value;

public class PureOutputValueHandleBuilder : BaseValueHandleBuilder
{
    public override IEnumerable<PureOutputValueHandle> Build(INode node) => HandlesValues.Select(handleValues =>
        new PureOutputValueHandle(handleValues.Label, handleValues.ValueType, node)).ToList();
}