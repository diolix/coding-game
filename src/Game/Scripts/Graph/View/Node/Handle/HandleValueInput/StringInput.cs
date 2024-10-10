using CodingGame.Scripts.Graph.Controller.Handle;
using GraphModel.Handle;

namespace CodingGame.Scripts.Graph.View.Node.Handle.HandleValueInput;

public partial class StringInput : Godot.LineEdit, IHandleModelDependant
{
    public IHandle Model { private get; set; }

    public override void _Ready()
    {
        TextChanged += HandleTextChanged;
    }

    private void HandleTextChanged(string newtext)
    {
        Model.Node.Input.Set(Model.Index, newtext);
    }
}