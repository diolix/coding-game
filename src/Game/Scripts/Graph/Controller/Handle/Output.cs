using Godot;
using GraphModel.Handle;

namespace CodingGame.Scripts.Graph.View.Controller.Handle;

public partial class Output : Godot.Node, IHandleEventController
{
    [Export] private Script.Graph.View.Draggable _draggable;
    [Export] private HandleEventBus _handleEventBus;
    [Export] private Control _handleIcon;
    public IHandle Model { private get; set; }

    private Vector2 _draggableInitialPosition;

    public override void _Ready()
    {
        _draggableInitialPosition = _draggable.Position;
        _draggable.OnDragStart += () =>
            _handleEventBus.OnOutputDragStarted?.Invoke(
                new() { Position = _handleIcon, Model = Model }, _draggable);
        
        _draggable.OnDragEnd += () =>
        {
            _handleEventBus.OnOutputDragEnded?.Invoke(new(){Model = Model, Position = _handleIcon});
            _draggable.Position = _draggableInitialPosition;
        };
    }
}