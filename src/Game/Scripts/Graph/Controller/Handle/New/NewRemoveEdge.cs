using Godot;
using GraphModel.NewHandle;

namespace CodingGame.Scripts.Graph.Controller.Handle.New;

public partial class NewRemoveEdge : ColorRect, INewHandleModelDependant
{
    [Export] private NewHandleEventBus _handleEventBus;
    public INewHandle Model { private get; set; }

    public override void _GuiInput(InputEvent @event)
    {
        if (@event.IsActionPressed("remove_edge")) _handleEventBus.OnDeleteEdgeAtHandle(Model);
    }
}