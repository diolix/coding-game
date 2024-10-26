using GraphModel.Values.PrimitiveType;

namespace GraphModel.Variable.TypeImplementation;

public class StringVariableModel(string name, StringValue value) : BaseVariableModel(name, value)
{
    public StringVariableModel(string name) : this(name, new StringValue("")) { }
    public StringVariableModel(string name, string value) : this(name, new StringValue(value)) { }
    public override StringValue Value { get; } = value;
}