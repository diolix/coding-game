using GraphModel.Values.PrimitiveType;

namespace GraphModel.Values;

public static class ValueFactory
{
    public static Value CreateValue(object value, ValueTypeEnum valueType)
    {
        return valueType switch
        {
            ValueTypeEnum.String => new StringValue((string)value),
            ValueTypeEnum.Bool => new BoolValue((bool)value),
            ValueTypeEnum.Object => new ObjectValue(value),
            ValueTypeEnum.Int => new IntValue((int)value),
            _ => throw new ArgumentOutOfRangeException(nameof(valueType), valueType, null)
        };
    }
    
    public static Value CreateValue(ValueTypeEnum valueType)
    {
        return valueType switch
        {
            ValueTypeEnum.String => new StringValue(),
            ValueTypeEnum.Bool => new BoolValue(),
            ValueTypeEnum.Object => new ObjectValue(),
            ValueTypeEnum.Int => new IntValue(),
            _ => throw new ArgumentOutOfRangeException(nameof(valueType), valueType, null)
        };
    }
}