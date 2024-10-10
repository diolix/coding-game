using Godot;
using GraphModel.Handle;
using GraphModel.NewHandle;

namespace CodingGame.Scripts.Graph.Controller.Handle;

public partial class Input : Area2D, IHandleModelDependant
{
    [Export] private Graph.Controller.Handle.HandleEventBus _handleEventBus;
    [Export] private Control _handleIcon;
    public IHandle Model { private get; set; }

    public override void _Ready()
    {
        AreaEntered += (body) =>
            _handleEventBus.OnOutputEnteredInput?.Invoke(new() { Position = _handleIcon, Model = Model });
        AreaExited += (body) =>
            _handleEventBus.OnOutputExitedInput?.Invoke(new() { Position = _handleIcon, Model = Model });
    }
}