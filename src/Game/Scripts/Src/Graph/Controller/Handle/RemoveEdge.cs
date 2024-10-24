using CodingGame.Scripts.Graph.Controller.Handle;
using Godot;
using GraphModel.Handle;

namespace CodingGame.Scripts.Src.Graph.Controller.Handle;

public partial class RemoveEdge : ColorRect, IHandleModelDependant
{
    [Export] private HandleEventBus _handleEventBus;
    public IHandle Model { private get; set; }

    public override void _GuiInput(InputEvent @event)
    {
        if (@event.IsActionPressed("remove_edge")) _handleEventBus.InvokeDeleteEdgeAtHandle(Model);
    }
}