using GraphModel.Values.PrimitiveType;

namespace GraphModel.Variable.TypeImplementation;

public class ObjectVariableModel(string name, ObjectValue value) : BaseVariableModel(name, value)
{
    public ObjectVariableModel(string name) : this(name, new ObjectValue(default!)) { }
    public ObjectVariableModel(string name, object value) : this(name, new ObjectValue(value)) { }
    public override ObjectValue Value { get; } = value;
}