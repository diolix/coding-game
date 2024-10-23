using GraphModel.Handle;
using GraphModel.Handle.Flow;
using GraphModel.Handle.Value;
using GraphModel.Handle.Value.Output;
using GraphModel.Node.HandleBuilder.Impure;

namespace GraphModel.Node.HandleBuilder;

public class ImpureOutputHandlesBuilder : BaseImpureHandleBuilder
{
    public override IEnumerable<IHandle> Build(INode node) => HandlesValues.Select<HandleValues, IHandle>(
        handleValues => handleValues switch
        {
            FlowHandleValues cachedValues => new OutputFlowHandle(cachedValues.Label, node),
            ValueHandleValues cachedValue =>
                new ImpureOutputValueHandle(cachedValue.Label, cachedValue.ValueType, node),
            _ => throw new ArgumentOutOfRangeException()
        }).ToList();
}