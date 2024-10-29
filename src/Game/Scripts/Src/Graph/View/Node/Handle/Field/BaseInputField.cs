#nullable enable
using Godot;
using GraphModel.Handle.Value.Input;

namespace CodingGame.Scripts.Src.Graph.View.Node.Handle.Field;

public abstract partial class BaseInputField : Godot.Node
{
    protected InputValueHandleWithField? Model;
    public void SetHanldeModel(InputValueHandleWithField model) => Model = model;
}