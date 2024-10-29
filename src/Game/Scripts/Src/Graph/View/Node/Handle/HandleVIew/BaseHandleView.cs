using CodingGame.Scripts.Src.Graph.Controller.Handle;
using Godot;
using GraphModel.Handle;

namespace CodingGame.Scripts.Src.Graph.View.Node.Handle.HandleVIew;

public abstract partial class BaseHandleView : Control
{
    [Export] private Label _label = null!;
    [Export] private ColorRect _icon = null!;
    [Export] private RemoveEdge _removeEdge = null!;

    public override void _Ready()
    {
        _label.Text = "";
        _icon.Visible = false;
    }

    public virtual void SetUp(IHandle model) {
        _icon.Visible = true;
        _label.Text = model.Label;
        _icon.Color = Color.FromHtml(model.Color.ToHex());
        _removeEdge.Model = model;
    }
}