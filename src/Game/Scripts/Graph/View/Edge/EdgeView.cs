using Godot;
using GraphModel.NewEdge;
using GraphModel.NewHandle;

namespace CodingGame.Scripts.Graph.View.Edge;

public partial class EdgeView : Godot.Node
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

    public bool Contains(INewHandle handle) => _model.Contains(handle);

    public void Remove()
    {
        _model.Remove();
        QueueFree();
    }
}