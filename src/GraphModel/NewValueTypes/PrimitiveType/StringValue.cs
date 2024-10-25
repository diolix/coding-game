namespace GraphModel.NewValueTypes.PrimitiveType;

public class StringValue : Value
{
    public StringValue(string value) : base(value) { }
    public StringValue() : base(typeof(string)) { }
    
    public string GetValue() => (string)GetObjValue();
    public string? GetValueOrNull() => (string?)GetObjValueOrNull();
    public override ValueTypeEnum TypeAsEnum => ValueTypeEnum.String;
}