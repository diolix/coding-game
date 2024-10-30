using CodingGame.Scripts.Src.Graph.View.Node.Handle.HandleVIew;
using Godot;

namespace CodingGame.Scripts.Src.Graph.Controller.Handle;

public partial class InputAreaController : Area2D
{
    [Export] private HandleEventBus _handleEventBus;
    [Export] private InputHandleView _inputHandleView;

    public override void _Ready()
    {
        AreaEntered += _ =>
            _handleEventBus.InvokeOutputEnteredInput(_inputHandleView);
        AreaExited += _ => _handleEventBus.InvokeOutputExitedInput(_inputHandleView);
    }
}