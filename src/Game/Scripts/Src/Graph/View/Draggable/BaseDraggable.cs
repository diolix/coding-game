using System;
using Godot;

namespace CodingGame.Scripts.Src.Graph.View.Draggable;

public abstract partial class BaseDraggable : Control
{
    [Export] private Control _target;
    private bool _isDragging;

    public event Action OnDragStart;
    public event Action OnDragEnd; 
    protected void HandleEvent(InputEvent guiEvent)
    {
        if (guiEvent.IsActionPressed("left_click"))
        {
            _isDragging = true;
            OnDragStart?.Invoke();
        }
        if (guiEvent.IsActionReleased("left_click"))
        {
            _isDragging = false;
            OnDragEnd?.Invoke();
        }
    }
    
    public override void _Input(InputEvent @event)
    {
        if (@event is not InputEventMouseMotion || !_isDragging) return;
        _target.GlobalPosition = GetGlobalMousePosition() - _target.PivotOffset;
    }
}