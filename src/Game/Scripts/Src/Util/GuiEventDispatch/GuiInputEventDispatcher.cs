using System;
using System.Collections.Generic;
using System.Linq;
using Godot;

namespace CodingGame.Scripts.Src.Util.GuiEventDispatch;

public partial class GuiInputEventDispatcher : Control
{
    [Export] private Control[] _controls;
    private IEnumerable<ICustomInputGuiEventListener> _guiEventListeners;
    public override void _Ready()
    {
        if (_controls.All(eventListener => eventListener is not ICustomInputGuiEventListener))
            throw new Exception("All GUI event listeners must implement IGuiEventListener");
        
        _guiEventListeners = _controls.OfType<ICustomInputGuiEventListener>();
    }

    public override void _GuiInput(InputEvent @event)
    {
        foreach (var guiEventListener in _guiEventListeners)
        {
            guiEventListener.OnGuiEvent(@event);
        }
    }
}