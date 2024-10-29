using Godot;

namespace CodingGame.Scripts.Src.Graph.View.Draggable;

public partial class DraggableDefaultGuiEvent : BaseDraggable
{
    public override void _GuiInput(InputEvent @event) => HandleEvent(@event);
}