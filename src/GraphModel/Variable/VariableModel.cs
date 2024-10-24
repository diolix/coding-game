namespace GraphModel.Variable;

public class VariableModel<RealType> : IVariable
{
    public string Name { get; }
    public ValueType ValueType { get; }
    private RealType _value;
    private readonly RealType _initialValue;
    public object GetValue() => _value ?? throw new InvalidOperationException();

    public VariableModel(string name, ValueType valueType, RealType value)
    {
        valueType.CoherentTypeAndValueType(value);
        Name = name;
        ValueType = valueType;
        _value = value;
        _initialValue = value;
    }

    public TypeWanted? SafeGetValueOfType<TypeWanted>()
    {
        if (typeof(RealType) == typeof(TypeWanted))
            return (TypeWanted)(object)_value!;
        return default;
    }
    
    public bool SafeSetValue(object value)
    {
        try
        {
            RealType valueAsRealType = (RealType)value;
            _value = valueAsRealType;
            return true;
        } catch (InvalidCastException e)
        {
            Console.Error.WriteLine($"The value type {value.GetType()} is not coherent with the generic type {typeof(RealType)}");
            return false;
        }
    }

    public void Reset() => _value = _initialValue;
}