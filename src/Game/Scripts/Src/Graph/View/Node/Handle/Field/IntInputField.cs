#nullable enable
using Godot;
using GraphModel.Handle.Value.Input;

namespace CodingGame.Scripts.Src.Graph.View.Node.Handle.Field;

public partial class IntInputField : SpinBox, IInputValueHandleWithFieldDependant
{
    private InputValueHandleWithField? _handleModel;

    public void SetHandleModel(InputValueHandleWithField handleModel)
    {
        _handleModel = handleModel;
        _handleModel.SetValue(0);
    }

    public override void _Ready() => ValueChanged += value => _handleModel?.SetValue((int) value);
}