#nullable enable
using CodingGame.Scripts.Src.Graph.Controller.Handle;
using CodingGame.Scripts.Src.Graph.View.Node.Handle.Field;
using Godot;
using GraphModel.Handle;

namespace CodingGame.Scripts.Src.Graph.View.Node.Handle.HandleVIew;

public partial class InputHandleView : BaseHandleView
{
    [Export] private InputAreaController _inputAreaController = null!;
    [Export] private InputFieldFactory _inputFieldFactory = null!;
    [Export] private Control _inputFieldContainer = null!;
    private Control? _inputField;

    public override void SetUp(IHandle model)
    {
        _inputField = _inputFieldFactory.CreateInputField(model);
        if (_inputField != null) _inputFieldContainer.AddChild(_inputField);
        _inputAreaController.Model = model;
        base.SetUp(model);
    }
    
    private void HideInputField() => _inputField?.Hide();
}