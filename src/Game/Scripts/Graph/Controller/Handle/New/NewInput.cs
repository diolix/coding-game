using Godot;
using GraphModel.NewHandle;

namespace CodingGame.Scripts.Graph.Controller.Handle.New;

public partial class NewInput : Area2D, INewHandleModelDependant
{
    [Export] private NewHandleEventBus _newHandleEventBus;
    [Export] private Control _handleIcon;
    public INewHandle Model { private get; set; }

    public override void _Ready()
    {
        AreaEntered += (body) =>
            _newHandleEventBus.OnOutputEnteredInput?.Invoke(new() { Position = _handleIcon, Model = Model });
        AreaExited += (body) =>
            _newHandleEventBus.OnOutputExitedInput?.Invoke(new() { Position = _handleIcon, Model = Model });
    }
}