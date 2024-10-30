#nullable enable
using CodingGame.Scripts.Src.Graph.View.Node.Handle.Field;
using Godot;
using GraphModel.Handle;

namespace CodingGame.Scripts.Src.Graph.View.Node.Handle.HandleVIew;

public partial class InputHandleView: BaseHandleView
{
    [Export] private InputFieldFactory _inputFieldFactory = null!;
    [Export] private Control _inputFieldContainer = null!;
    private Control? _inputField;

    public InputHandleView(){}
    public InputHandleView(IHandle handleModel, ColorRect icon) : base(handleModel, icon){}
    
    public override void SetUp(IHandle model)
    {
        _inputField = _inputFieldFactory.CreateInputField(model);
        if (_inputField != null) _inputFieldContainer.AddChild(_inputField);
        base.SetUp(model);
    }
    
    public void HideInputField() => _inputField?.Hide();
    public void ShowInputField() => _inputField?.Show();
}