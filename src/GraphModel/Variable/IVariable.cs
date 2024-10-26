using GraphModel.NewValueTypes;

namespace GraphModel.Variable;

public interface IVariable 
{
    string Name { get; }
    ValueTypeEnum AsTypeEnum { get; }
    void SetValue(object value);
    void SetValue(Value value);
    Value Value { get; }
    void Reset();
}