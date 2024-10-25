using GraphModel.Handle.Value.Input;
using GraphModel.NewValueTypes;
using GraphModel.Node;

namespace GraphModel.Handle.Value.Output;

public abstract class BaseOutputValueHandle(string label, ValueTypeEnum valueTypeEnum, INode node) : BaseValueHandle(label, valueTypeEnum, node)
{
    protected NewValueTypes.Value CachedValue = ValueFactory.CreateValue(valueTypeEnum);

    protected override bool IsCompatible(IHandle handle) => handle is InputValueHandle inputValueHandle &&
                                                         inputValueHandle.ValueTypeEnum.Equals(ValueTypeEnum);
    
    public void SetCachedValue(NewValueTypes.Value value){
        CachedValue = value;
    }
}