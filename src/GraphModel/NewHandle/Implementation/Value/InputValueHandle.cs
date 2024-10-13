using GraphModel.NewHandle.Interfaces;
using GraphModel.Util;

namespace GraphModel.NewHandle.Implementation;

public class InputValueHandle : BaseNewHandle, IInputNewHandle, IValueNewHandle
{
    public ValueType ValueType { get; }

    public override ColorHex Color => ValueType.GetColor();

    public InputValueHandle(string label, ExecutionContext executionContext, ValueType valueType) : base(label, executionContext)
    {
        ValueType = valueType;
    }
    public override bool IsCompatible(INewHandle handle)
    {
        return handle is IOutputNewHandle outputHandle && 
               outputHandle is IValueNewHandle valueHandle &&
               valueHandle.ValueType.Equals(ValueType);
    }

    public object GetValue()
    {
        throw new NotImplementedException();
    }
}