using Godot;
using GraphModel.Edge;
using GraphModel.Handle;

namespace CodingGame.Scripts.Src.Graph.View.Edge;

public partial class EdgeView : Godot.Node
{
    [Export] private ControlLine _controlLine;

    private IEdge _model;
    public IEdge Model
    {
        get => _model;
        set
        {
            _model = value;
            _controlLine.DefaultColor = Color.FromHtml(_model.Color.ToHex());
        }
    }
    public EdgeView(){}
    public EdgeView(ControlLine controlLine)
    {
        _controlLine = controlLine;
    }
    public void SetPosition(Control from, Control to)
    {
        _controlLine.Set(from, to);
    }

    public bool Contains(IHandle handle) => _model.Contains(handle);

    public void Remove()
    {
        _model.Remove();
        QueueFree();
    }
}