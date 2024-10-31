using GraphModel.Values.PrimitiveType;

namespace GraphModel.Variable.TypeImplementation;

public class IntVariableModel(string name, IntValue value) : BaseVariableModel(name, value)
{
    public IntVariableModel(string name) : this(name, new IntValue(0)) { }
    public IntVariableModel(string name, int value) : this(name, new IntValue(value)) { }
    public override IntValue Value { get; } = value;
}