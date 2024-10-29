#nullable enable
using Godot;
using GraphModel.Handle.Value.Input;

namespace CodingGame.Scripts.Src.Graph.View.Node.Handle.Field;

public partial class BoolInputField : BaseInputField
{
    [Export] private CheckBox _checkBox = null!;
    
    public override void _Ready() => _checkBox.Toggled += newValue => Model?.SetValue(newValue);
}