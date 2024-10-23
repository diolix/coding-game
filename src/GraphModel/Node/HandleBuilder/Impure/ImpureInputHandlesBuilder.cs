using GraphModel.Handle;
using GraphModel.Handle.Flow;
using GraphModel.Handle.Value;
using GraphModel.Node.HandleBuilder.Impure;

namespace GraphModel.Node.HandleBuilder;

public class ImpureInputHandlesBuilder : BaseImpureHandleBuilder
{
    public override IEnumerable<IHandle> Build(INode node) => HandlesValues.Select<HandleValues, IHandle>(
        handlesValues => handlesValues switch
        {
            FlowHandleValues values => new InputFlowHandle(values.Label, node),
            ValueHandleValues values => new InputValueHandle(values.Label, values.ValueType, node),
            _ => throw new ArgumentOutOfRangeException()
        }).ToList();
}