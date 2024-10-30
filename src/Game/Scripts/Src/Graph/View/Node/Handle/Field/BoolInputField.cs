#nullable enable
using Godot;
using GraphModel.Handle.Value.Input;

namespace CodingGame.Scripts.Src.Graph.View.Node.Handle.Field;

public partial class BoolInputField : CheckBox, IInputValueHandleWithFieldDependant
{
    private InputValueHandleWithField? _model;
    public void SetHandleModel(InputValueHandleWithField model) 
    {
        _model = model;
        _model.SetValue(false);
    }
    public override void _Ready() => Toggled += newValue => _model?.SetValue(newValue);
}