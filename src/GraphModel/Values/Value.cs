using GraphModel.Util;

namespace GraphModel.NewValueTypes;

public abstract class Value
{
    protected Value(Type type)
    {
        Type = type;
    }

    protected Value(object value)
    {
        _value = value;
        Type = value.GetType();
    }

    protected Value(object value, Type type)
    {
        _value = value;
        Type = type;
    }

    private object? _value;
    private Type Type { get; }
    protected object GetObjValue() => _value ?? throw new InvalidAccessToValueException(this);
    public object? GetObjValueOrNull() => _value;

    public ColorHex Color => ValueTypeColor.ColorFor(TypeAsEnum);

    public void SetObjValue(object value)
    {
        if (Type == typeof(object))
        {
            _value = value;
            return;
        }

        if (value.GetType() != Type)
            throw new InvalidCastException();

        _value = value;
    }

    public bool IsNull => _value is null;
    public bool IsOfType<T>() => Type == typeof(T);
    public bool IsOfType(Type type) => Type == type;
    public bool IsOfType(Value value) => Type == value.Type;
    public bool IsOfType(object obj) => Type == obj.GetType();
    public bool IsOfType(ValueTypeEnum valueTypeEnum) => valueTypeEnum == TypeAsEnum;
    public abstract ValueTypeEnum TypeAsEnum { get; }
}

public class InvalidAccessToValueException(Value value)
    : Exception($"Access to null value in object : ${value}, to safely access the value use the method GetObjValueOrNull()")
{
    public Value Value { get; } = value;
}