using Godot;
using GraphModel.Handle;
using GraphModel.NewHandle;

namespace CodingGame.Scripts.Graph.Controller.Handle;

public partial class Output : Godot.Node, IHandleModelDependant
{
    [Export] private Script.Graph.View.Draggable _draggable;
    [Export] private Graph.Controller.Handle.HandleEventBus _handleEventBus;
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