using Godot;

namespace CodingGame.Scripts.Graph.View.Edge;

public partial class ControlLine : Line2D
{
    private Control _from;
    private Control _to;

    public void Set(Control from, Control to)
    {
        _from = from;
        _to = to;
        Points = new[] { _from.GlobalPosition, _to.GlobalPosition };
    }

    public override void _Process(double delta)
    {
        if(_from == null || _to == null) return;
        Points = new[] { _from.GlobalPosition + _from.PivotOffset, _to.GlobalPosition + _to.PivotOffset };
    }
}