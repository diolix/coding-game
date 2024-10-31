#nullable enable
using Godot;
using GraphModel.Handle;
using GraphModel.Handle.Value.Input;
using GraphModel.Values;

namespace CodingGame.Scripts.Src.Graph.View.Node.Handle.Field;

[GlobalClass]
public partial class InputFieldFactory : Resource
{
    [Export] private PackedScene _stringFieldScene = null!;
    [Export] private PackedScene _boolFieldScene = null!;
    [Export] private PackedScene _intFieldScene = null!;

    public Control? CreateInputField(IHandle model)
    {
        if (model is not InputValueHandleWithField inputHandle)
            return null;

        return inputHandle.ValueTypeEnum switch
        {
            ValueTypeEnum.String => CreateInputField<StringInputField>(inputHandle, _stringFieldScene),
            ValueTypeEnum.Bool => CreateInputField<BoolInputField>(inputHandle, _boolFieldScene),
            ValueTypeEnum.Int => CreateInputField<IntInputField>(inputHandle, _intFieldScene),
            _ => null
        };
    }

    private Control CreateInputField<T>(InputValueHandleWithField model, PackedScene inputFieldScene)
        where T : Control, IInputValueHandleWithFieldDependant
    {
        var inputField = inputFieldScene.Instantiate<T>();
        inputField.SetHandleModel(model);
        return inputField;
    }
}