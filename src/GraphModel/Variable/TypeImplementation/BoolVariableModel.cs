using GraphModel.NewValueTypes.PrimitiveType;

namespace GraphModel.Variable.TypeImplementation;

public class BoolVariableModel(string name, BoolValue value) : BaseVariableModel(name, value)
{
    public BoolVariableModel(string name) : this(name, new BoolValue(false)) { }
    public BoolVariableModel(string name, bool value) : this(name, new BoolValue(value)) { }
    public override BoolValue Value { get; } = value;
}