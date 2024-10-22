using CodingGame.Scripts.Graph.View;
using Godot;
using GraphModel.Handle;

namespace CodingGame.Scripts.Graph.Controller.Handle;

public partial class Output : Node, IHandleModelDependant
{
    [Export] private Draggable _draggable;
    [Export] private Handle.HandleEventBus _handleEventBus;
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