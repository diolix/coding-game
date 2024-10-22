using Godot;
using GraphModel.NewHandle;

namespace CodingGame.Scripts.Graph.Controller.Handle.New;

public partial class RemoveEdge : ColorRect, IHandleModelDependant
{
    [Export] private HandleEventBus _handleEventBus;
    public INewHandle Model { private get; set; }

    public override void _GuiInput(InputEvent @event)
    {
        if (@event.IsActionPressed("remove_edge")) _handleEventBus.OnDeleteEdgeAtHandle(Model);
    }
}