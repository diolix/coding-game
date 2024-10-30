using CodingGame.Scripts.Src.Graph.View.Draggable;
using CodingGame.Scripts.Src.Graph.View.Node.Handle.HandleVIew;
using Godot;
using GraphModel.Handle;

namespace CodingGame.Scripts.Src.Graph.Controller.Handle;

public partial class OutputDraggableController : Godot.Node
{
    [Export] private BaseDraggable _draggable;
    [Export] private HandleEventBus _handleEventBus;
    [Export] private OutputHandleView _outputHandleView;

    private Vector2 _draggableInitialPosition;

    public override void _Ready()
    {
        _draggableInitialPosition = _draggable.Position;
        _draggable.OnDragStart += () =>
            _handleEventBus.InvokeOutputDragStarted(_outputHandleView, _draggable);

        _draggable.OnDragEnd += () =>
        {
            _handleEventBus.InvokeOutputDragEnded();
            _draggable.Position = _draggableInitialPosition;
        };
    }
}