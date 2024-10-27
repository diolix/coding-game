using GraphModel.Values;
using GraphModel.Variable.TypeImplementation;

namespace GraphModel.Variable;

public static class VariableFactory
{
    public static BaseVariableModel CreateVariable(string name, ValueTypeEnum valueTypeEnum)
    {
        return valueTypeEnum switch
        {
            ValueTypeEnum.String => new StringVariableModel(name),
            ValueTypeEnum.Bool => new BoolVariableModel(name),
            ValueTypeEnum.Object => new ObjectVariableModel(name),
            _ => throw new NotImplementedException()
        };
    }
}