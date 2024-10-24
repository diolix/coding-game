namespace GraphModel.Variable;

public static class VariableFactory
{
    public static IVariable CreateVariable(string name, ValueType valueType)
    {
        if (valueType.Equals(ValueType.Bool)) return CreateBoolVariable(name, false);
        if (valueType.Equals(ValueType.String)) return CreateStringVariable(name, "");
        throw new ArgumentException($"can't create variable of type : {valueType}");
    }

    private static IVariable CreateBoolVariable(string name, bool value) =>
        new VariableModel<bool>(name, ValueType.Bool, value);

    private static IVariable CreateStringVariable(string name, string value) =>
        new VariableModel<string>(name, ValueType.String, value);
}