using System;
using Godot;

namespace CodingGame.Scripts.Graph.View;

public partial class Draggable : Control
{
	[Export] private Control _target;
	private bool _isDragging;

	public event Action OnDragStart;
	public event Action OnDragEnd; 
	public override void _GuiInput(InputEvent @event)
	{
		if (@event.IsActionPressed("left_click"))
		{
			OnDragStart?.Invoke();
			_isDragging = true;
		}
		
		if (@event.IsActionReleased("left_click"))
		{
			OnDragEnd?.Invoke();
			_isDragging = false;
		}
	}

	public override void _Input(InputEvent @event)
	{
		if (@event is not InputEventMouseMotion || !_isDragging) return;
		_target.GlobalPosition = GetGlobalMousePosition() - _target.PivotOffset;
	}
}