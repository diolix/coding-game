using Godot;
using GraphModel.NewHandle;

namespace CodingGame.Scripts.Graph.Controller.Handle.New;

public partial class Input : Area2D, IHandleModelDependant
{
    [Export] private HandleEventBus _handleEventBus;
    [Export] private Control _handleIcon;
    public INewHandle Model { private get; set; }

    public override void _Ready()
    {
        AreaEntered += (body) =>
            _handleEventBus.OnOutputEnteredInput?.Invoke(new() { Position = _handleIcon, Model = Model });
        AreaExited += (body) =>
            _handleEventBus.OnOutputExitedInput?.Invoke(new() { Position = _handleIcon, Model = Model });
    }
}