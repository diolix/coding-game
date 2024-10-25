using GraphModel.NewValueTypes.PrimitiveType;

namespace GraphModel.Variable;

public class BoolVariableModel(string name, BoolValue value) : BaseVariableModel(name, value)
{
    public BoolVariableModel(string name) : this(name, new BoolValue()) { }
    public override BoolValue Value { get; } = value;
}