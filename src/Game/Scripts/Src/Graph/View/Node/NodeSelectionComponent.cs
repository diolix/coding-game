using CodingGame.Scripts.Src.Util.GuiEventDispatch;
using Godot;

namespace CodingGame.Scripts.Src.Graph.View.Node;

public partial class NodeSelectionComponent : Control, ICustomInputGuiEventListener
{
    [Export] private Controller.Node.NodeSelectionEventBus _nodeSelectionEventBus;
    [Export] private NodeView _nodeView;

    public void OnGuiEvent(InputEvent guiEvent)
    {
        if (!guiEvent.IsActionPressed("left_click")) return;
        _nodeSelectionEventBus.InvokeSelectNode(_nodeView);
    }
}