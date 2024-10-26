using CodingGame.Scripts.Graph.Controller.Handle;
using Godot;
using GraphModel.Handle;

namespace CodingGame.Scripts.Src.Graph.View.Node.Handle;

public partial class HandleView : Control
{
    [Export] private Label _label;
    [Export] private ColorRect _icon;
    [Export] private Godot.Node[] _handleEventControllers;
    
    private IHandle _model;

    public override void _Ready()
    {
        _label.Text = "";
        _icon.Visible = false;
    }

    public void SetUp(IHandle model) {
        _model = model;
        _icon.Visible = true;
        _label.Text = model.Label;
        _icon.Color = Color.FromHtml(model.Color.ToHex());
        foreach (var handleEventController in _handleEventControllers)
        {
            ((IHandleModelDependant)handleEventController).Model = model;
        }
    }

    // private void ShowInput()
    // {
    //     if (_model is not IHandleValue handleValue) return;
    //     if (handleValue.Type.Equals(ValueTypeEnum.String))
    //         _stringInput.Show();
    //     else if (handleValue.Type.Equals(ValueTypeEnum.Int))
    //         _intInput.Show();
    //     else if (handleValue.Type.Equals(ValueTypeEnum.Bool))
    //         _boolInput.Show();
    // }

    // private void HideInput()
    // {
    //     _intInput.Hide();
    //     _stringInput.Hide();
    //     _boolInput.Hide();
    // }
}