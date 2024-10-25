using GraphModel.NewValueTypes;

namespace GraphModel.Variable;

public static class VariableFactory
{
    public static BaseVariableModel CreateVariable(string name, ValueTypeEnum valueTypeEnum)
    {
        switch (valueTypeEnum)
        {
            case ValueTypeEnum.String:
                return new StringVariableModel(name);
            case ValueTypeEnum.Bool:
                return new BoolVariableModel(name);
            case ValueTypeEnum.Object:
                return new ObjectVariableModel(name);
            default:
                throw new NotImplementedException();
        }
    }
}