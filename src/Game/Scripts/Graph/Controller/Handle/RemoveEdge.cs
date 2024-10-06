using Godot;
using GraphModel.Handle;

namespace CodingGame.Scripts.Graph.View.Controller.Handle;

public partial class RemoveEdge : ColorRect, IHandleEventController
{
    [Export] private Scripts.Graph.View.Controller.Handle.HandleEventBus _handleEventBus;
    public IHandle Model { private get; set; }

    public override void _GuiInput(InputEvent @event)
    {
        if (@event.IsActionPressed("remove_edge")) _handleEventBus.OnDeleteEdgeAtHandle(Model);
    }

    
}