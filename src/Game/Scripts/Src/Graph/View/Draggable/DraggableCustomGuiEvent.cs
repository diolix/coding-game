using System;
using CodingGame.Scripts.Src.Util.GuiEventDispatch;
using Godot;

namespace CodingGame.Scripts.Src.Graph.View.Draggable;

public partial class DraggableCustomGuiEvent : BaseDraggable, ICustomInputGuiEventListener
{
    public void OnGuiEvent(InputEvent guiEvent) => HandleEvent(guiEvent);
}