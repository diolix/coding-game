using System.Drawing;

namespace GraphModel.NewValueTypes.PrimitiveType;

public class BoolValue : Value
{
    public BoolValue(bool value) : base(value) { }
    public BoolValue() : base(typeof(bool)) { }
    
    public bool GetValue() => (bool)GetObjValue();
    public bool? GetValueOrNull() => (bool?)GetObjValueOrNull();
    public override ValueTypeEnum TypeAsEnum => ValueTypeEnum.Bool;
}