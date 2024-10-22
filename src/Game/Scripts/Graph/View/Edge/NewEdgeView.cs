using Godot;
using GraphModel.NewEdge;

namespace CodingGame.Scripts.Graph.View.Edge;

public partial class NewEdgeView : Godot.Node
{
    [Export] private ControlLine _controlLine;

    private INewEdge _model;
    public INewEdge Model
    {
        get => _model;
        set
        {
            _model = value;
            _controlLine.DefaultColor = Color.FromHtml(_model.Color.ToHex());
        }
    }

    public void SetPosition(Control from, Control to)
    {
        _controlLine.Set(from, to);
    }
}