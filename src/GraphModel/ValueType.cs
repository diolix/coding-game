using System.Drawing;
using CodingGame.Script.Util;
using GraphModel.Util;

namespace GraphModel;

public class ValueType : Enumeration
{
    public static readonly ValueType AnyValue = new(1, nameof(AnyValue), Color.SaddleBrown, typeof(object));
    public static readonly ValueType String = new(2, nameof(String), Color.Pink, typeof(string));
    public static readonly ValueType Int = new(3, nameof(Int), Color.Blue, typeof(int));
    public static readonly ValueType Bool = new(4, nameof(Bool), Color.Green, typeof(bool));
    
    private readonly ColorHex _color;
    private readonly Type _type;
    public ColorHex GetColor() => _color;

    public void CoherentTypeAndValueType(Type type)
    {
        if (type != _type)
            throw new ArgumentException(
                $"The type {type.Name} is not coherent with the value type {Name}");
    }
    
    private ValueType(int id, string name, Color color, Type type) : base(id, name)
    {
        _type = type;
        _color = new ColorHex(color);
    }
}