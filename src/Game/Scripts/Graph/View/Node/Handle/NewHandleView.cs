using CodingGame.Scripts.Graph.Controller.Handle.New;
using Godot;
using GraphModel.NewHandle;

namespace CodingGame.Scripts.Graph.View.Node.Handle;

public partial class NewHandleView : Control
{
    [Export] private Label _label;
    [Export] private ColorRect _icon;
    [Export] private Godot.Node[] _handleEventControllers;
    
    private INewHandle _model;

    public override void _Ready()
    {
        _label.Text = "";
        _icon.Visible = false;
    }

    public void SetUp(INewHandle model) {
        _model = model;
        _icon.Visible = true;
        _label.Text = model.Label;
        _icon.Color = Color.FromHtml(model.Color.ToHex());
        foreach (var handleEventController in _handleEventControllers)
        {
            ((INewHandleModelDependant)handleEventController).Model = model;
        }
    }

    // private void ShowInput()
    // {
    //     if (_model is not IHandleValue handleValue) return;
    //     if (handleValue.Type.Equals(ValueType.String))
    //         _stringInput.Show();
    //     else if (handleValue.Type.Equals(ValueType.Int))
    //         _intInput.Show();
    //     else if (handleValue.Type.Equals(ValueType.Bool))
    //         _boolInput.Show();
    // }

    // private void HideInput()
    // {
    //     _intInput.Hide();
    //     _stringInput.Hide();
    //     _boolInput.Hide();
    // }
}