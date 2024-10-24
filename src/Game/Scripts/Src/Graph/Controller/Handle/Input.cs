using CodingGame.Scripts.Graph.Controller.Handle;
using Godot;
using GraphModel.Handle;

namespace CodingGame.Scripts.Src.Graph.Controller.Handle;

public partial class Input : Area2D, IHandleModelDependant
{
    [Export] private HandleEventBus _handleEventBus;
    [Export] private Control _handleIcon;
    public IHandle Model { private get; set; }

    public override void _Ready()
    {
        AreaEntered += (_) =>
            _handleEventBus.InvokeOutputEnteredInput(new() { Position = _handleIcon, Model = Model });
        AreaExited += (_) => _handleEventBus.InvokeOutputExitedInput(new() { Position = _handleIcon, Model = Model });
    }
}