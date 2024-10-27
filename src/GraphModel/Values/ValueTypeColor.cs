using System.Drawing;
using GraphModel.Util;

namespace GraphModel.Values;

public static class ValueTypeColor
{
    public static ColorHex ColorFor(ValueTypeEnum typeEnum)
    {
        switch (typeEnum)
        {
            case ValueTypeEnum.String:
                return new(Color.Pink);
            case ValueTypeEnum.Bool:
                return new(Color.LightBlue);
            case ValueTypeEnum.Object:
                return new(Color.Gray);
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}