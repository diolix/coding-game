#nullable enable
using Godot;
using GraphModel.Handle.Value.Input;

namespace CodingGame.Scripts.Src.Graph.View.Node.Handle.Field;

public partial class StringInputField : BaseInputField
{
    [Export] private LineEdit _lineEdit = null!;
    public override void _Ready() => _lineEdit.TextChanged += newValue => Model?.SetValue(newValue);
}