using CodingGame.Scripts.Graph.View.Controller.Handle;
using Godot;
using GraphModel.Handle;

namespace CodingGame.Scripts.Graph.View.Node.Handle;

public partial class HandleView : Control
{
    [Export] private Label _label;
    [Export] private ColorRect _icon;
    [Export] private Godot.Node[] _handleEventControllers;

    public override void _Ready()
    {
        _label.Text = "";
        _icon.Visible = false;
    }

    public void SetUp(IHandle model) {
        _icon.Visible = true;
        _label.Text = model.Label;
        _icon.Color = Color.FromHtml(model.Color.ToHex());
        foreach (var handleEventController in _handleEventControllers)
        {
            ((IHandleEventController)handleEventController).Model = model;
        }
    }
}