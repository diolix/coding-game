using Godot;
using GraphModel.Node;
using HandlesInstantiator = CodingGame.Scripts.Src.Graph.Controller.Handle.HandlesInstantiator;

namespace CodingGame.Scripts.Src.Graph.View.Node;

public partial class NodeView  : Control
{
    [Export] private StyleBoxFlat _selectedBackGround;
    [Export] private StyleBoxFlat _unselectedBackGround;
    [Export] private Label _nameLabel;
    [Export] private HandlesInstantiator _handlesInstantiator = null!;
    public INode Model { get; private set; }
    private bool _selected;
    
    public void BuildVisual(INode model)
    {
        Model = model;
        _nameLabel.Text = Model.Name;
        _handlesInstantiator.BuildHandles(model);
    }

    public void Deselect() => AddThemeStyleboxOverride("panel", _unselectedBackGround);
    public void Select() => AddThemeStyleboxOverride("panel", _selectedBackGround);
}