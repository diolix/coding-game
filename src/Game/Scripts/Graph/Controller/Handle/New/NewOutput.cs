using Godot;
using GraphModel.NewHandle;

namespace CodingGame.Scripts.Graph.Controller.Handle.New;

public partial class NewOutput : Node, INewHandleModelDependant
{
    [Export] private Script.Graph.View.Draggable _draggable;
    [Export] private NewHandleEventBus _newHandleEventBus;
    [Export] private Control _handleIcon;
    public INewHandle Model { private get; set; }

    private Vector2 _draggableInitialPosition;

    public override void _Ready()
    {
        _draggableInitialPosition = _draggable.Position;
        _draggable.OnDragStart += () =>
            _newHandleEventBus.OnOutputDragStarted?.Invoke(
                new() { Position = _handleIcon, Model = Model }, _draggable);
        
        _draggable.OnDragEnd += () =>
        {
            _newHandleEventBus.OnOutputDragEnded?.Invoke(new(){Model = Model, Position = _handleIcon});
            _draggable.Position = _draggableInitialPosition;
        };
    }
}