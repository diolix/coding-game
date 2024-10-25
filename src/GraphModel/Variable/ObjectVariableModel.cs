using GraphModel.NewValueTypes.PrimitiveType;

namespace GraphModel.Variable;

public class ObjectVariableModel(string name, ObjectValue value) : BaseVariableModel(name, value)
{
    public ObjectVariableModel(string name) : this(name, new ObjectValue()) { }
    public override ObjectValue Value { get; } = value;
}