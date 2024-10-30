#nullable enable
using Godot;
using GraphModel.Handle.Value.Input;

namespace CodingGame.Scripts.Src.Graph.View.Node.Handle.Field;

public partial class StringInputField : LineEdit, IInputValueHandleWithFieldDependant
{
    private InputValueHandleWithField? _model;
    public void SetHandleModel(InputValueHandleWithField model) {
        _model = model;
        _model.SetValue("");
    }
    public override void _Ready() => TextChanged += newValue => _model?.SetValue(newValue);
}