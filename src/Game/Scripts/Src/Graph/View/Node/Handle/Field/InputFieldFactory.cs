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

    public Control? CreateInputField(IHandle model)
    {
        if (model is not InputValueHandleWithField inputHandle)
            return null;

        return inputHandle.ValueTypeEnum switch
        {
            ValueTypeEnum.String => CreateInputField(inputHandle, _stringFieldScene.Instantiate<StringInputField>()),
            ValueTypeEnum.Bool => CreateInputField(inputHandle, _boolFieldScene.Instantiate<BoolInputField>()),
            _ => null
        };
    }

    private Control CreateInputField(InputValueHandleWithField model, Control inputField)
    {
        ((IInputValueHandleWithFieldDependant)inputField).SetHandleModel(model);
        return inputField;
    }
}