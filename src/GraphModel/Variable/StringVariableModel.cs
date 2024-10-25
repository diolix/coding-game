using GraphModel.NewValueTypes.PrimitiveType;

namespace GraphModel.Variable;

public class StringVariableModel(string name, StringValue value) : BaseVariableModel(name, value)
{
    public StringVariableModel(string name) : this(name, new StringValue()) { }
    public override StringValue Value { get; } = value;
}