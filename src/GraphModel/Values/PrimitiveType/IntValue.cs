namespace GraphModel.Values.PrimitiveType;

public class IntValue : Value
{
    public IntValue(int value) : base(value) { }
    public IntValue() : base(typeof(int)){}
    
    public int GetValue() => (int)GetObjValue();
    public int? GetValueOrNull() => (int?)GetObjValueOrNull();
    public override ValueTypeEnum TypeAsEnum => ValueTypeEnum.Int;
    
}