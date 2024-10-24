using GraphModel.Handle.Value.Output;

namespace GraphModel.Node.HandleBuilder.Value;

public class ImpureOutputValueHandleBuilder : BaseValueHandleBuilder
{
    public override IEnumerable<ImpureOutputValueHandle> Build(INode node) => HandlesValues.Select(handleValues =>
        new ImpureOutputValueHandle(handleValues.Label, handleValues.ValueType, node));
}