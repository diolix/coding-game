using System.Drawing;

namespace GraphModel.Util;

public class ColorHex
{
    private readonly Color _color;
    public ColorHex(Color color)
    {
        _color = color;
    }
    
    public string ToHex() => $"#{_color.R:X2}{_color.G:X2}{_color.B:X2}";
}