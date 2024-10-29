using Godot;

namespace CodingGame.Scripts.Src.Util.GuiEventDispatch;

public interface ICustomInputGuiEventListener
{
    void OnGuiEvent(InputEvent guiEvent);
}