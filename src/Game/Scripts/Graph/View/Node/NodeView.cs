using System;
using CodingGame.Scripts.Graph.View.Controller.Handle;
using Godot;
using GraphModel.Node.BaseNodes;

namespace CodingGame.Scripts.Graph.View.Node;

public partial class NodeView : Control
{
    [Export] private StyleBoxFlat _selectedBackGround;
    [Export] private StyleBoxFlat _unselectedBackGround;
    [Export] private Label _nameLabel;
    [Export] private HandlesInstantiator _handlesInstantiator;
    public event Action<bool> OnSelectChanged; 
    public INode Model { get; private set; }
    private bool _selected;
    
    public void BuildVisual(INode model)
    {
        Model = model;
        _nameLabel.Text = Model.Name;
        _handlesInstantiator.BuildHandles(model);
    }

    public override void _GuiInput(InputEvent @event)
    {
        if (_selected || !@event.IsActionPressed("left_click")) return;
        _selected = true;
        OnSelectChanged?.Invoke(true);
        AddThemeStyleboxOverride("panel", _selectedBackGround);
    }

    public override void _Input(InputEvent @event)
    {
        if (!_selected || !@event.IsActionPressed("left_click")) return;
        _selected = false;
        OnSelectChanged?.Invoke(false);
        AddThemeStyleboxOverride("panel", _unselectedBackGround);
    }

    public float GetHeight() => Size.Y;
}