using GraphModel.Values;

namespace GraphModel.Variable;

public abstract class BaseVariableModel(string name, object initialValue) : IVariable
{
    protected BaseVariableModel(string name, Value value) : this(name, (value.GetObjValueOrNull() ?? default)!) { }
    public string Name { get; } = name;
    public void Reset() => SetValue(initialValue);
    public void SetValue(object value) => Value.SetObjValue(value);
    public void SetValue(Value value) => Value.SetObjValue(value.GetObjValueOrNull() ?? default!);
    public abstract Value Value { get; }
    public ValueTypeEnum AsTypeEnum => Value.TypeAsEnum;
}