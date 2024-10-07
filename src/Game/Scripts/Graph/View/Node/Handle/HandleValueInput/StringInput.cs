using CodingGame.Scripts.Graph.Controller.Handle;
using GraphModel.Handle;

namespace CodingGame.Scripts.Graph.View.Node.Handle.HandleValueInput;

public partial class StringInput : Godot.Control, IHandleModelDependant
{
    public IHandle Model { private get; set; }
    
    
}