namespace GraphModel.NewValueTypes.PrimitiveType;

public class ObjectValue : Value
{
    public ObjectValue() : base(typeof(object)) { }
    public ObjectValue(object value) : base(value, typeof(object)) { }
    public override ValueTypeEnum TypeAsEnum => ValueTypeEnum.Object;
    public object GetValue() => GetObjValue();
    public object? GetValueOrNull() => GetObjValueOrNull();
}